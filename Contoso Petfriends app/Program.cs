// the ourAnimals array will store the following: 
using System.Runtime.CompilerServices;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "3";
            animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
            animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
            animalNickname = "Lion";
            suggestedDonation = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

// #5 display the top-level menu options

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }


    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            //List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            break;
        case "2":
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }
            bool validEntry = false;
            // get species (cat or dog) - string animalSpecies is a required field 
            do
            {
                Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalSpecies = readResult.ToLower();
                    if (animalSpecies != "dog" && animalSpecies != "cat")
                    {
                        validEntry = false;
                    }
                    else
                    {
                        validEntry = true;
                    }

                }

            } while (validEntry == false);
            // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
            animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
            // get the pet's age. can be ? at initial entry. 
            do
            {
                int petAge;
                Console.WriteLine("Enter the pet's age or enter ? if unknown");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalAge = readResult;
                    if (animalAge != "?")
                    {
                        validEntry = int.TryParse(animalAge, out petAge);
                    }
                    else
                    {
                        validEntry = true;
                    }
                }
            } while (validEntry == false);
            // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
            do
            {
                Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPhysicalDescription = readResult.ToLower();
                    if (animalPhysicalDescription == "")
                    {
                        animalPhysicalDescription = "tbd";
                    }
                }
            } while (animalPhysicalDescription == "");
            // get a description of the pet's personality - animalPersonalityDescription can be blank.
            // get a description of the pet's personality - animalPersonalityDescription can be blank.
            do
            {
                Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPersonalityDescription = readResult.ToLower();
                    if (animalPersonalityDescription == "")
                    {
                        animalPersonalityDescription = "tbd";
                    }
                }
            } while (animalPersonalityDescription == "");
            // get the pet's nickname. animalNickname can be blank.
            do
            {
                Console.WriteLine("Enter a nickname for the pet");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalNickname = readResult.ToLower();
                    if (animalNickname == "")
                    {
                        animalNickname = "tbd";
                    }
                }
            } while (animalNickname == "");
            // store the pet information in the ourAnimals array (zero based)
            ourAnimals[petCount, 0] = "ID #: " + animalID;
            ourAnimals[petCount, 1] = "Species: " + animalSpecies;
            ourAnimals[petCount, 2] = "Age: " + animalAge;
            ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
            ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
            while (anotherPet == "y" && petCount < maxPets)
            {
                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;
                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }
            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    if (!ourAnimals[i, 2].Any(c => char.IsDigit(c)))
                    {
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}\n");
                        var input = Console.ReadLine();
                        int numberOut;
                        bool isNumber = int.TryParse(input, out numberOut);
                        while (!isNumber)
                        {
                            Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}\n");
                            input = Console.ReadLine();
                            isNumber = int.TryParse(input, out numberOut);
                        }
                        ourAnimals[i, 2] = "Age: " + input;
                        Console.WriteLine($"Age now set to {input} for {ourAnimals[i, 0]}");
                    }
                    if (ourAnimals[i, 4] == "Physical description: ")
                    {
                        Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");
                        var input = Console.ReadLine();
                        while (input == "" || input == null)
                        {
                            Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");
                            input = Console.ReadLine();
                        }
                        ourAnimals[i, 4] = "Physical description: " + input;
                    }
                }
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "4":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    if (ourAnimals[i, 3] == "Nickname: ")
                    {
                        Console.WriteLine($"Enter a nickame for {ourAnimals[i, 0]}\n");
                        var input = Console.ReadLine();
                        while (input == "" || input == null)
                        {
                            Console.WriteLine($"Enter a nickame for {ourAnimals[i, 0]}\n");
                            input = Console.ReadLine();
                        }
                        ourAnimals[i, 3] = "Nickname: " + input;
                    }
                    if (ourAnimals[i, 5] == "Personality: ")
                    {
                        Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                        var input = Console.ReadLine();
                        while (input == "" || input == null)
                        {
                            Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                            input = Console.ReadLine();
                        }
                        ourAnimals[i, 5] = "Personality: " + input;
                    }
                }
            }
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "5":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            string dogCharacteristic = "";

            while (dogCharacteristic == "")
            {
                // have the user enter physical characteristics to search for
                Console.WriteLine($"\nEnter one desired dog characteristics to search for");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                }
            }
            string dogDescription = "";
            bool noMatchesDog = true;
            // #6 loop through the ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    // #7 Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    if (dogDescription.Contains(dogCharacteristic))
                    {
                        noMatchesDog = false;
                        Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                        Console.WriteLine(dogDescription);
                    }
                }
            }
            if (noMatchesDog)
            {
                Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        default:
            break;
    }

} while (menuSelection != "exit");
