
// Datos de mascotas
const int maxPets = 8;
string[,] ourAnimals = new string[maxPets, 6];

// Inicializar array con datos de ejemplo
for (int i = 0; i < 4; i++)
{
    ourAnimals[i, 0] = "ID #: ID" + i;
    ourAnimals[i, 1] = "Species: " + (i % 2 == 0 ? "Perro" : "Gato");
    ourAnimals[i, 2] = "Age: " + (i + 1) + " años";
    ourAnimals[i, 3] = "Nickname: Mascota" + i;
    ourAnimals[i, 4] = "Physical description: " + (i % 2 == 0 ? "Pequeño, pelo corto" : "Mediano, pelo largo");
    ourAnimals[i, 5] = "Personality: " + (i % 2 == 0 ? "Juguetón" : "Tranquilo");
}

string menuSelection = "";
do
{
    Console.WriteLine("\nMenú Principal:");
    Console.WriteLine("1. Listar todas las mascotas");
    Console.WriteLine("2. Agregar nueva mascota");
    Console.WriteLine("3. Editar mascota existente");
    Console.WriteLine("4. Buscar mascotas");
    Console.WriteLine("exit - Salir del programa");
    Console.Write("Seleccione una opción: ");

    menuSelection = Console.ReadLine()?.Trim().ToLower();

    switch (menuSelection)
    {
        case "1":
            Console.WriteLine("\nListado de Mascotas:");
            for (int i = 0; i < maxPets; i++)
            {
                if (!string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    Console.WriteLine($"\nMascota {i}:");
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        case "2":
            string otraMascota;
            do
            {
                int petCount = 0;
                int nuevaPosicion = -1;

                // Contar mascotas y encontrar posición vacía
                for (int i = 0; i < maxPets; i++)
                {
                    if (!string.IsNullOrEmpty(ourAnimals[i, 0]))
                    {
                        petCount++;
                    }
                    else if (nuevaPosicion == -1)
                    {
                        nuevaPosicion = i;
                    }
                }

                if (petCount >= maxPets)
                {
                    Console.WriteLine("\n¡Hemos alcanzado el límite máximo de mascotas!");
                    break;
                }

                Console.WriteLine($"\nActualmente tenemos {petCount} mascotas. Podemos aceptar {(maxPets - petCount)} más.");

                // Validar especie (perro o gato)
                string animalSpecies;
                bool validEntry;
                do
                {
                    Console.Write("\nIngrese especie (perro/gato): ");
                    animalSpecies = Console.ReadLine()?.Trim().ToLower();
                    validEntry = animalSpecies == "perro" || animalSpecies == "gato";
                    if (!validEntry)
                    {
                        Console.WriteLine("Especie no válida. Por favor ingrese 'perro' o 'gato'.");
                    }
                } while (!validEntry);

                // Generar ID (P1, P2, G3, etc.)
                string animalID = animalSpecies.Substring(0, 1).ToUpper() + (petCount + 1).ToString();
                
                // Obtener edad
                string animalAge;
                do
                {
                    Console.Write("Ingrese la edad de la mascota o ? si se desconoce: ");
                    animalAge = Console.ReadLine()?.Trim();
                    if (animalAge != "?")
                    {
                        validEntry = int.TryParse(animalAge, out _);
                        if (!validEntry)
                        {
                            Console.WriteLine("Edad no válida. Ingrese un número o ?.");
                        }
                    }
                    else
                    {
                        validEntry = true;
                    }
                } while (!validEntry);

                // Obtener apodo
                Console.Write("Apodo: ");
                string animalNickname = Console.ReadLine()?.Trim();
                animalNickname = string.IsNullOrEmpty(animalNickname) ? "Sin apodo" : animalNickname;

                // Obtener descripción física
                Console.Write("Descripción física: ");
                string animalPhysicalDescription = Console.ReadLine()?.Trim();
                animalPhysicalDescription = string.IsNullOrEmpty(animalPhysicalDescription) ? "Por determinar" : animalPhysicalDescription;

                // Obtener descripción de personalidad
                Console.Write("Descripción de personalidad: ");
                string animalPersonalityDescription = Console.ReadLine()?.Trim();
                animalPersonalityDescription = string.IsNullOrEmpty(animalPersonalityDescription) ? "Por determinar" : animalPersonalityDescription;

                // Almacenar la información con el formato deseado
                ourAnimals[nuevaPosicion, 0] = "ID #: " + animalID;
                ourAnimals[nuevaPosicion, 1] = "Species: " + animalSpecies;
                ourAnimals[nuevaPosicion, 2] = "Age: " + animalAge;
                ourAnimals[nuevaPosicion, 3] = "Nickname: " + animalNickname;
                ourAnimals[nuevaPosicion, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[nuevaPosicion, 5] = "Personality: " + animalPersonalityDescription;

                Console.WriteLine("\n¡Mascota agregada exitosamente!");

                if (petCount + 1 < maxPets)
                {
                    Console.Write("\n¿Desea agregar otra mascota? (s/n): ");
                    otraMascota = Console.ReadLine()?.Trim().ToLower();
                }
                else
                {
                    Console.WriteLine("\n¡Hemos alcanzado el límite máximo de mascotas!");
                    otraMascota = "n";
                }
            } while (otraMascota == "s");
            
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            break;

        // Resto de los casos del switch...
    }
} while (menuSelection != "exit");