using System.Collections.Generic;

public static class Universe {

    public static string[] domains = { "gmail.com", "hotmail.com", "yahoo.com", "outlook.com", "icloud.com", "yandex.com" };

    public static string[] usernames = {"john123", "sarah456", "jdoe789", "jane1234", "jimmy567", "julia890", "jessica123", "david456", "mary789", "mike1234", "emily567", "chris890", "lisa123", "peter456", "kate789", "rachel1234", "steve567", "jennifer890", "mark123", "karen456", "tom789", "jenny1234", "brandon567", "natalie890", "oliver123", "lucy456", "george789", "susan1234", "robert567", "jessie890", "andrew123", "beth456", "samuel789", "carol1234", "jared567", "laura890", "daniel123", "katie456", "rick789", "maggie1234", "anthony567", "kelly890", "travis123", "kristen456", "julian789", "maria1234", "tyler567", "jess456", "joe789", "abby1234", "maxwell567"};
    
    public static string[] genres = {"Adventure", "RPG", "Strategy", "Sports", "Fighting", "Puzzle", "Survival", "Horror", "Shooter"};

    public static Dictionary<string, int> critics = new Dictionary<string, int>() { 
        {"SaqueCritic", 100},
        {"PDPE", 60},
        {"Game Location", 10},
        {"Green Mesa", 50},
    };

    public static Dictionary<string, string[]> descriptions = new Dictionary<string, string[]>
    {
        { "Adventure", new string[]
            {
                "Embark on a perilous quest to save the world from evil forces, uncovering ancient mysteries and outwitting cunning enemies along the way!",
                "Explore breathtaking landscapes, solve mind-boggling puzzles, and make tough choices that shape your character's destiny.",
                "Venture into the unknown, armed only with your wit and a trusty companion, as you navigate treacherous dungeons and encounter bizarre creatures.",
                "Unleash your inner explorer as you delve into immersive worlds filled with hidden treasures, secret passages, and unexpected surprises.",
                "Prepare for a rollercoaster ride of emotions as you witness captivating storytelling, heartwarming friendships, and a healthy dose of danger!"
            }
        },
        { "RPG", new string[]
            {
                "Create your own hero and embark on an epic adventure, leveling up your skills, collecting legendary loot, and slaying fearsome monsters!",
                "Immerse yourself in a richly detailed world where every decision you make has consequences, shaping the fate of both your character and the realm.",
                "Master the art of character customization, from choosing unique abilities to customizing your appearance, and become the ultimate force to be reckoned with.",
                "Unleash devastating spells, wield mighty weapons, and forge alliances as you navigate a complex web of political intrigue and supernatural threats.",
                "Get ready to spend countless hours grinding for experience points, because in this world, even a level 99 hero still needs to defeat a level 1 slime!"
            }
        },
        { "Strategy", new string[]
            {
                "Put your strategic thinking to the test as you lead armies, build empires, and outsmart your opponents on the battlefield.",
                "Carefully plan your every move, considering resources, terrain, and the enemy's tactics, to claim victory and establish yourself as a brilliant tactician.",
                "Command a diverse range of units, from fearless knights and powerful sorcerers to cunning spies and fearsome war machines, in epic clashes of might and wit.",
                "Engage in intricate diplomacy, form alliances, and manipulate rival factions to ensure your empire rises to the top while others crumble in your wake.",
                "Remember, a true strategist always has a backup plan—unless, of course, their backup plan has a backup plan. Because being overly prepared is just good strategy!"
            }
        },
        { "Sports", new string[]
            {
                "Step onto the field and experience the thrill of intense competition as you play your favorite sports, from soccer to basketball, with stunning realism.",
                "Perfect your skills, strategize with your team, and execute jaw-dropping moves that will leave your opponents in awe and wondering if they should switch careers.",
                "Live out your sports fantasies without breaking a sweat (or risking an injury), and guide your team to victory with expert tactics and flawless teamwork.",
                "Feel the adrenaline rush as you go head-to-head against legendary athletes, and prove that you're not just a button masher but a true virtual sports superstar!",
                "Remember, in the world of sports, anything is possible—unless, of course, you accidentally hit the wrong button and end up performing an unexpected victory dance."
            }
        },
        { "Fighting", new string[]
            {
                "Enter the ring, flex your virtual muscles, and prepare to pummel your opponents in electrifying battles that will leave them begging for mercy.",
                "Unleash a devastating array of punches, kicks, and flashy combos, mastering each fighter's unique moveset to become an unstoppable force in the virtual arena.",
                "Choose from a roster of diverse characters, each with their own compelling backstory, and witness epic clashes between heroes, villains, and everything in between.",
                "Dodge, block, and counter with lightning-fast reflexes, making split-second decisions that can mean the difference between victory and an embarrassing knockout.",
                "Prepare for some serious face-offs, but remember to keep it light-hearted—because nothing diffuses tension like a fighter who accidentally trips over their own feet."
            }
        },
        { "Puzzle", new string[]
            {
                "Challenge your brain with mind-bending puzzles that will test your logic, spatial awareness, and ability to think outside the box.",
                "Solve intricate riddles, unlock hidden secrets, and manipulate your environment to overcome obstacles and advance to the next level of puzzling greatness.",
                "Enter a world of brainteasers and conundrums, where every puzzle solved brings you closer to unraveling a larger mystery that will leave you craving more.",
                "Get ready to spend hours staring at your screen, scratching your head, and occasionally letting out triumphant cheers as you crack the code and triumph over the enigmatic challenge.",
                "Remember, in the realm of puzzles, there's no such thing as an unsolvable mystery—unless, of course, you accidentally drop a puzzle piece down a black hole."
            }
        },
        { "Survival", new string[]
            {
                "Stranded on a deserted island, fight against the harsh elements, hunger, and dangerous wildlife as you struggle to stay alive against all odds.",
                "Gather resources, craft essential tools, and build shelters to protect yourself from the unforgiving environment and lurking threats that come out at night.",
                "Navigate treacherous terrains, explore mysterious caves, and uncover hidden secrets as you strive to find a way back to civilization.",
                "Test your survival skills and adaptability as you face unexpected challenges, from sudden weather changes to unexpected encounters with ferocious beasts.",
                "Remember, survival isn't just about physical strength—it's also about resourcefulness, resilience, and a healthy dose of luck. Good luck out there!"
            }
        },
        { "Horror", new string[]
            {
                "Enter a spine-chilling world of terror, where every shadow hides unspeakable horrors and every creaking floorboard sends shivers down your spine.",
                "Navigate through haunting environments, solve macabre puzzles, and uncover the dark secrets that lie within the cursed halls of abandoned mansions and sinister institutions.",
                "Feel your heart race and your palms sweat as you're relentlessly pursued by otherworldly entities that only exist to fuel your nightmares.",
                "Immerse yourself in atmospheric sound design, realistic graphics, and hair-raising jump scares that will make you question your sanity with each passing moment.",
                "Remember, in the realm of horror, fear is your constant companion. So, brace yourself, turn off the lights, and prepare for a night of sleepless terror!"
            }
        },
        { "Shooter", new string[]
            {
                "Lock and load! Engage in adrenaline-pumping firefights, as you take on the role of a highly skilled soldier battling against enemy forces with an arsenal of high-powered weapons.",
                "Immerse yourself in heart-pounding action, navigating dynamic battlefields, and strategically using cover to gain the upper hand against relentless foes.",
                "Coordinate with your teammates in intense multiplayer battles, where communication, teamwork, and precise aim are the keys to victory.",
                "Experience the thrill of epic explosions, jaw-dropping stunts, and over-the-top action sequences that make even the most daring Hollywood films look tame.",
                "Whether you're fighting in futuristic sci-fi environments or gritty war-torn landscapes, prepare for non-stop adrenaline as you mow down enemies with bullets, explosives, and sheer badassery.",
                "Just remember, in the world of shooters, it's not about how many bullets you fire—it's about how many enemies you can take down while looking ridiculously cool!"
            }
        },
    };

    public static string[] spamDescriptions = new string[] {
        "Get rich quick! Join our exclusive club of money magnets and live the life you've always dreamed of. No more counting pennies, only dollar bills flying around!",
        "Earn $1000 per day! It's as easy as sipping a cup of coffee. Just sit back, relax, and watch your bank account grow faster than a caffeinated cheetah!",
        "Struggling to lose those extra pounds? Say goodbye to salads and hello to our magical weight loss potion. It's so effective, you'll start floating like a helium balloon!",
        "Enlarge your... uh, self-confidence! Our revolutionary product will boost your ego to skyscraper heights. You'll feel like the superhero version of yourself in no time!",
        "Congratulations! You've won a free vacation to a tropical paradise. Prepare to soak up the sun, sip fruity drinks, and practice your best synchronized swimming moves with dolphins!",
        "Click here for a special offer! It's like finding a hidden treasure chest full of discounts and amazing deals. Just don't forget your pirate hat and eye patch!",
        "Limited time offer! Buy now and unleash your inner shopaholic. It's the perfect excuse to treat yourself to something fancy while avoiding the guilt trip!",
        "Make money from home with no effort! Our foolproof system will turn you into a money-making maestro while you lounge in your pajamas. Hello, financial freedom!",
        "Searching for love? Look no further! Our dating service connects you with charming singles who will make your heart skip a beat. Prepare for a love story that even Nicholas Sparks would envy!",
        "You're a winner! Claim your prize and celebrate like there's no tomorrow. Pop open the champagne, put on your victory dance playlist, and get ready to make it rain confetti!",
    };
}