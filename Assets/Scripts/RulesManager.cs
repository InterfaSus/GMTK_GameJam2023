using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RulesManager : MonoBehaviour
{
    
    public GameObject rulesPanel;

    public List<(string, Func<Mail, (bool, string)>)> rules;

    void Start() {
        
        GenerateRandomRules(Persistents.RulesAmount[Persistents.Level - 1]);
    }

    public (bool, (string, bool)[]) CheckRules(Mail mail) {
        
        List<(string, bool)> rulesCorrectness = new List<(string, bool)>();

        foreach (var rule in rules) {
            
            var (result, ruleName) = rule.Item2(mail);
            rulesCorrectness.Add((ruleName, result));
        }

        return (rulesCorrectness.All(x => x.Item2), rulesCorrectness.ToArray());
    }

    public void GenerateRandomRules(int amount) {

        rules = new List<(string, Func<Mail, (bool, string)>)>();

        // Spam rule
        string ruleMsg = $"Reject everything with spam in the description";
        rules.Add((ruleMsg, (mail) => {
            return Rules.NotSpam(mail);
        }));

        // Rating rule
        int threshold = UnityEngine.Random.Range(3, 5);
        ruleMsg = $"Stars rating must be at least {threshold}";

        rules.Add((ruleMsg, (mail) => {
            return Rules.Rating(mail, threshold);
        }));

        // From rule
        bool isAcceptDomain = UnityEngine.Random.Range(0, 2) == 0;

        int fromAmount = isAcceptDomain ? UnityEngine.Random.Range(3, 5) : UnityEngine.Random.Range(1, 3);
        string[] domains = new string[fromAmount];
        string[] domainsCopy = (string[])Universe.domains.Clone();

        for (int i = 0; i < fromAmount; i++) {
            int index = UnityEngine.Random.Range(0, domainsCopy.Length);
            domains[i] = domainsCopy[index];
            domainsCopy = domainsCopy.Where((val, idx) => idx != index).ToArray();
        }

        if (isAcceptDomain) {
            ruleMsg = $"ONLY ACCEPT emails from: {string.Join(", ", domains)}";
            rules.Add((ruleMsg, (mail) => {
                return Rules.FromValid(mail, domains);
            }));
        }
        else {
            ruleMsg = $"REJECT emails from: {string.Join(", ", domains)}";
            rules.Add((ruleMsg, (mail) => {
                return Rules.FromNeither(mail, domains);
            }));
        }

        // Critics Rating rule
        int indexCritic = UnityEngine.Random.Range(0, 4);

        int maxVal = Universe.critics.ElementAt(indexCritic).Value;
        int limit = UnityEngine.Random.Range(maxVal / 2, 3 * maxVal / 4 + 1);
        ruleMsg = $"At least {limit} points from {Universe.critics.ElementAt(indexCritic).Key}";
        rules.Add((ruleMsg, (mail) => {
            return Rules.CriticsRating(mail, Universe.critics.ElementAt(indexCritic).Key, limit);
        }));

        // Genre Valid rule
        bool isAcceptGenre = UnityEngine.Random.Range(0, 2) == 0;

        int genreAmount = isAcceptGenre ? UnityEngine.Random.Range(3, 5) : UnityEngine.Random.Range(1, 3);
        string[] genres = new string[genreAmount];
        string[] genresCopy = (string[])Universe.genres.Clone();

        for (int i = 0; i < genreAmount; i++) {
            int index = UnityEngine.Random.Range(0, genresCopy.Length);
            genres[i] = genresCopy[index];
            genresCopy = genresCopy.Where((val, idx) => idx != index).ToArray();
        }

        if (isAcceptGenre) {

            ruleMsg = $"Main genre must be: {string.Join(", ", genres)}";
            rules.Add((ruleMsg, (mail) => {
                return Rules.GenreValid(mail, genres);
            }));
        }
        else {
            ruleMsg = $"Main genre can't be: {string.Join(", ", genres)}";
            rules.Add((ruleMsg, (mail) => {
                return Rules.GenreNeither(mail, genres);
            }));
        }

        // Subgenre Valid rule
        int subgenreAmount = UnityEngine.Random.Range(3, 5);
        string[] subgenres = new string[subgenreAmount];
        string[] subgenresCopy = (string[])Universe.genres.Clone();

        for (int i = 0; i < subgenreAmount; i++) {
            int index = UnityEngine.Random.Range(0, subgenresCopy.Length);
            subgenres[i] = subgenresCopy[index];
            subgenresCopy = subgenresCopy.Where((val, idx) => idx != index).ToArray();
        }

        ruleMsg = $"Must one of these subgenres: {string.Join(", ", subgenres)}";
        rules.Add((ruleMsg, (mail) => {
            return Rules.SubgenreValid(mail, subgenres);
        }));

        rules = rules.Take(amount).ToList();
    }
}
