class Program
{
    enum Room
    {
        FallenTree,
        FrozenLake,
        ToolShed,
        MainCabin,
        MasterBedroom,
        CabinBasement,
        Helipad
    }

    static void Main(string[] args)
    {
        Room currentRoom = Room.FallenTree;
        
        bool hasKey = false;
        bool hasTorch = false;
        bool hasFuel = false;
        bool isToolShedLocked = true;
        bool usedTorch = false;
        
        bool gameRunning = true;
        bool printRoomDescription = true;
        
        Console.WriteLine("While camping in the snowy mountains, a horrible roar echoed into the night.");
        Console.WriteLine("Something was hunting you. You took off on your snowmobile, heading back to the cabin.");
        Console.WriteLine("Falling snow obscured your vision. When you saw it blocking your path, it was too late.");
        Console.WriteLine("You open your eyes minutes later, dusting off the snow.");
        
        while (gameRunning)
        {
            if (printRoomDescription)
            {
                switch (currentRoom)
                {
                    case Room.FallenTree:
                        Console.WriteLine("A fallen tree blocks the previously open road.");
                        Console.WriteLine("Your snowmobile sticks halfway out of the snow, heavily damaged after colliding into the tree.");
                        Console.WriteLine("It is unlikely anything can be scrapped from it.");
                        Console.WriteLine("The path extends to the west.");
                        break;

                    case Room.FrozenLake:
                        Console.WriteLine("You walk out onto a frozen lake. The ice is deadly thin.");
                        if (isToolShedLocked)
                        {
                            Console.WriteLine("There are paths to the east and to the west. A rickety tool shed sits on the southern shore, but it is locked.");
                        }
                        else
                        {
                            Console.WriteLine("There are paths to the east and to the west. A rickety tool shed sits on the southern shore, its door wide open.");
                        }
                        break;

                    case Room.ToolShed:
                        Console.WriteLine("You enter the cramped tool shed. It reeks of mold.");
                        if (hasTorch)
                        {
                            Console.WriteLine("The shelves have been emptied of anything of value.");
                        }
                        else
                        {
                            Console.WriteLine("A torch sits on one of the many shelves.");
                        }
                        Console.WriteLine("The doorway leads to the north.");
                        break;

                    case Room.MainCabin:
                        Console.WriteLine("You enter the main cabin. Its grand entryway is devoid of warmth.");
                        Console.WriteLine("The main doors lead out to the east. Stairs can be taken west, north, or south.");
                        break;

                    case Room.MasterBedroom:
                        Console.WriteLine("You enter a large master bedroom. The mattress has been torn to shreds.");
                        if (hasKey)
                        {
                            Console.WriteLine("The room has been emptied of anything important.");
                        }
                        else
                        {
                            Console.WriteLine("An old key sits on the nightstand. It might be important.");
                        }
                        Console.WriteLine("The stairs lead down to the east.");
                        break;

                    case Room.CabinBasement:
                        Console.WriteLine("You enter the cabin's basement. Its dark, but a shattered window lets in some light.");
                        if (hasFuel)
                        {
                            Console.WriteLine("The basement is empty. It would be unwise to stay here any longer.");
                        }
                        else
                        {
                            Console.WriteLine("A canister of fuel sits underneath the window.");
                            Console.WriteLine("It seems like it may have been placed there for a reason.");
                            Console.WriteLine("Picking it up without some precaution would be a bad idea.");
                            Console.WriteLine("You should find a weapon, maybe a torch.");
                        }
                        Console.WriteLine("The stairs lead up to the south.");
                        break;

                    case Room.Helipad:
                        Console.WriteLine("You walk out into the open air, where a helipad awaits.");
                        Console.WriteLine("The helicopter is low on fuel. If you want to get out here, you'll need more.");
                        Console.WriteLine("The stairs lead down to the north.");
                        break;
                }
                
                printRoomDescription = false;
            }
            
            Console.Write("\nWhat do you want to do? > ");
            string input = Console.ReadLine().Trim().ToLower();
            
            string[] parts = input.Split(new char[] { ' ' }, 2);
            string command = parts[0];
            string argument = parts.Length > 1 ? parts[1].Trim() : "";
            
            if (argument == "")
            {
                Console.WriteLine("Your request is incomplete.");
                if (command == "move")
                {
                    Console.WriteLine($"Where do you want to {command}?");
                }
                if (command == "take" || command == "use")
                {
                    Console.WriteLine($"What do you want to {command}?");
                }
                continue;
            }
            
            switch (currentRoom)
            {
                case Room.FallenTree:
                    if (command == "move")
                    {
                        if (argument == "west") { currentRoom = Room.FrozenLake; printRoomDescription = true; }
                        else { Console.WriteLine("You cannot move in that direction from here."); }
                    }
                    else if (command == "take") { Console.WriteLine("There is nothing here to take."); }
                    else if (command == "use") { Console.WriteLine($"You cannot use the {argument} here."); }
                    else { Console.WriteLine("I do not know that command."); }
                    break;
                
                case Room.FrozenLake:
                    if (command == "move")
                    {
                        if (argument == "east") { currentRoom = Room.FallenTree; printRoomDescription = true; }
                        else if (argument == "west") { currentRoom = Room.MainCabin; printRoomDescription = true; }
                        else if (argument == "south") 
                        { 
                            if (isToolShedLocked)
                            {
                                Console.WriteLine("The tool shed door is locked tightly. You need a key.");
                            }
                            else
                            {
                                currentRoom = Room.ToolShed; 
                                printRoomDescription = true; 
                            }
                        }
                        else { Console.WriteLine("You cannot move in that direction from here."); }
                    }
                    else if (command == "take") { Console.WriteLine("There is nothing here to take."); }
                    else if (command == "use") 
                    { 
                        if (argument == "key")
                        {
                            if (hasKey)
                            {
                                if (isToolShedLocked)
                                {
                                    isToolShedLocked = false;
                                    Console.WriteLine("You push the key into the lock. As it turns, the key snaps, but the door opens.");
                                    hasKey = false;
                                }
                            }
                            else { Console.WriteLine("You do not have a key."); }
                        }
                        else if (argument == "torch")
                        {
                            if (hasTorch)
                            {
                                Console.WriteLine("You light the torch, illuminating the lake's icy surface.");
                                Console.WriteLine("It responds to the heat quickly, and cracks under your weight. You fall through.");
                                Console.WriteLine("The water is frigid, and the ice, which seemed so thin from above, is impossible to break through from below.");
                                Console.WriteLine("You have died.");
                                gameRunning = false;
                            }
                            else { Console.WriteLine("You do not have a torch."); }
                        }
                        else { Console.WriteLine($"You cannot use the {argument} here."); }
                    }
                    else { Console.WriteLine("I do not know that command."); }
                    break;
                
                case Room.ToolShed:
                    if (command == "move")
                    {
                        if (argument == "north") { currentRoom = Room.FrozenLake; printRoomDescription = true; }
                        else { Console.WriteLine("You cannot move in that direction from here."); }
                    }
                    else if (command == "take") 
                    { 
                        if (argument == "torch")
                        {
                            if (!hasTorch) { hasTorch = true; Console.WriteLine("You pick up the torch. Its flame can provide light or ward off danger."); }
                            else { Console.WriteLine("You already have the torch."); }
                        }
                        else { Console.WriteLine($"There is no {argument} here to take."); }
                    }
                    else if (command == "use") { Console.WriteLine($"You cannot use the {argument} here."); }
                    else { Console.WriteLine("I do not know that command."); }
                    break;
                
                case Room.MainCabin:
                    if (command == "move")
                    {
                        if (argument == "east") { currentRoom = Room.FrozenLake; printRoomDescription = true; }
                        else if (argument == "west") { currentRoom = Room.MasterBedroom; printRoomDescription = true; }
                        else if (argument == "north") { currentRoom = Room.CabinBasement; printRoomDescription = true; }
                        else if (argument == "south") { currentRoom = Room.Helipad; printRoomDescription = true; }
                        else { Console.WriteLine("You cannot move in that direction from here."); }
                    }
                    else if (command == "take") { Console.WriteLine("There is nothing here to take."); }
                    else if (command == "use") { Console.WriteLine($"You cannot use the {argument} here."); }
                    else { Console.WriteLine("I do not know that command."); }
                    break;
                
                case Room.MasterBedroom:
                    if (command == "move")
                    {
                        if (argument == "east") { currentRoom = Room.MainCabin; printRoomDescription = true; }
                        else { Console.WriteLine("You cannot move in that direction from here."); }
                    }
                    else if (command == "take") 
                    { 
                        if (argument == "key")
                        {
                            if (!hasKey) { hasKey = true; Console.WriteLine("You pick up the old key."); }
                            else { Console.WriteLine("You already took the key."); }
                        }
                        else { Console.WriteLine($"There is no {argument} here to take."); }
                    }
                    else if (command == "use") { Console.WriteLine($"You cannot use the {argument} here."); }
                    else { Console.WriteLine("I do not know that command."); }
                    break;
                
                case Room.CabinBasement:
                    if (command == "move")
                    {
                        if (argument == "south") { currentRoom = Room.MainCabin; printRoomDescription = true; }
                        else { Console.WriteLine("You cannot move in that direction from here."); }
                    }
                    else if (command == "take") 
                    { 
                        if (argument == "fuel")
                        {
                            if (!hasFuel)
                            {
                                hasFuel = true;
                                Console.WriteLine("As you reach for the fuel, a large clawed paw swipes at you from the window.");
                                if (usedTorch)
                                {
                                    Console.WriteLine("The beast misses, and you ward it off with the torch's flame.");
                                    Console.WriteLine("Its roars fade as it runs away. You pick up the fuel canister.");
                                }
                                else
                                {
                                    Console.WriteLine("The beast grabs you and lifts you through the broken window, roaring victoriously.");
                                    Console.WriteLine("You have died.");
                                    gameRunning = false;
                                }
                            }
                            else { Console.WriteLine("You already took the fuel."); }
                        }
                        else { Console.WriteLine($"There is no {argument} here to take."); }
                    }
                    else if (command == "use")
                    {
                        if (argument == "torch")
                        {
                            if (hasTorch) { usedTorch = true; Console.WriteLine("You light the torch."); }
                            else { Console.WriteLine("You do not have a torch."); }
                        }
                        else { Console.WriteLine($"You cannot use the {argument} here."); }
                    }
                    else { Console.WriteLine("I do not know that command."); }
                    break;
                
                case Room.Helipad:
                    if (command == "move")
                    {
                        if (argument == "north") { currentRoom = Room.MainCabin; printRoomDescription = true; }
                        else { Console.WriteLine("You cannot move in that direction from here."); }
                    }
                    else if (command == "take") { Console.WriteLine("There is nothing here to take."); }
                    else if (command == "use") 
                    { 
                        if (argument == "fuel")
                        {
                            if (hasFuel)
                            {
                                Console.WriteLine("You quickly refuel the helicopter using the canister.");
                                Console.WriteLine("As you lift away into the sky, you hear a wailing, defeated roar.");
                                Console.WriteLine("You have survived.");
                                gameRunning = false;
                            }
                            else { Console.WriteLine("You don't have any fuel to use."); }
                        }
                        else { Console.WriteLine($"You cannot use the {argument} here."); }
                    }
                    else { Console.WriteLine("I do not know that command."); }
                    break;
            }
        }

        Console.WriteLine("\nThank you for playing!");
        Console.ReadLine();
    }
}