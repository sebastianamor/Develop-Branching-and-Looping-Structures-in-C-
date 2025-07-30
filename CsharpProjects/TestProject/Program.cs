// ペットデータ (Datos de mascotas)
const int maxPets = 8;
string[,] ourAnimals = new string[maxPets, 6];

// サンプルデータで配列を初期化 (Inicializar array con datos de ejemplo)
for (int i = 0; i < 4; i++)
{
    ourAnimals[i, 0] = "ID #: ID" + i;
    ourAnimals[i, 1] = "種類: " + (i % 2 == 0 ? "犬" : "猫"); // Species: Perro / Gato
    ourAnimals[i, 2] = "年齢: " + (i + 1) + "歳"; // Age: X años
    ourAnimals[i, 3] = "ニックネーム: ペット" + i; // Nickname: Mascota
    ourAnimals[i, 4] = "身体的特徴: " + (i % 2 == 0 ? "小型、短毛" : "中型、長毛"); // Physical description: Pequeño, pelo corto / Mediano, pelo largo
    ourAnimals[i, 5] = "性格: " + (i % 2 == 0 ? "遊び好き" : "落ち着いている"); // Personality: Juguetón / Tranquilo
}

string menuSelection = "";
do
{
    Console.WriteLine("\nメインメニュー:"); // Menú Principal:
    Console.WriteLine("1. 全てのペットを一覧表示"); // 1. Listar todas las mascotas
    Console.WriteLine("2. 新しいペットを追加"); // 2. Agregar nueva mascota
    Console.WriteLine("3. 既存のペットを編集"); // 3. Editar mascota existente
    Console.WriteLine("4. ペットを検索"); // 4. Buscar mascotas
    Console.WriteLine("exit - プログラムを終了"); // exit - Salir del programa
    Console.Write("オプションを選択してください: "); // Seleccione una opción:

    menuSelection = Console.ReadLine()?.Trim().ToLower();

    switch (menuSelection)
    {
        case "1":
            Console.WriteLine("\nペット一覧:"); // Listado de Mascotas:
            for (int i = 0; i < maxPets; i++)
            {
                if (!string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    Console.WriteLine($"\nペット {i}:"); // Mascota X:
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\nEnterを押して続行してください.."); // Presione Enter para continuar..
            Console.ReadLine();
            break;

        case "2":
            string otraMascota;
            do
            {
                int petCount = 0;
                int nuevaPosicion = -1;

                // ペットを数え、空いている位置を見つける (Contar mascotas y encontrar posición vacía)
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
                    Console.WriteLine("\n最大ペット数に達しました！"); // ¡Hemos alcanzado el límite máximo de mascotas!
                    break;
                }
                Console.WriteLine($"\n現在、{petCount}匹のペットがいます。あと{(maxPets - petCount)}匹追加できます。"); // Actualmente tenemos X mascotas. Podemos aceptar Y más.

                // 種類の検証 (犬または猫) (Validar especie (perro o gato))
                string animalSpecies;
                bool validEntry;
                do
                {
                    Console.Write("\n種類を入力してください (犬/猫): "); // Ingrese especie (perro/gato):
                    animalSpecies = Console.ReadLine()?.Trim().ToLower();
                    validEntry = animalSpecies == "perro" || animalSpecies == "gato"; // Mantengo "perro" y "gato" en español para la lógica de validación
                    if (!validEntry)
                    {
                        Console.WriteLine("無効な種類です。「犬」または「猫」を入力してください。"); // Especie no válida. Por favor ingrese 'perro' o 'gato'.
                    }
                } while (!validEntry);

                // IDを生成 (P1, P2, G3など) (Generar ID (P1, P2, G3, etc.))
                string animalID = animalSpecies.Substring(0, 1).ToUpper() + (petCount + 1).ToString();

                // 年齢を取得 (Obtener edad)
                string animalAge;
                do
                {
                    Console.Write("ペットの年齢を入力してください。不明な場合は「?」: "); // Ingrese la edad de la mascota o ? si se desconoce:
                    animalAge = Console.ReadLine()?.Trim();
                    if (animalAge != "?")
                    {
                        validEntry = int.TryParse(animalAge, out _);
                        if (!validEntry)
                        {
                            Console.WriteLine("無効な年齢です。数字または「?」を入力してください。"); // Edad no válida. Ingrese un número o ?.
                        }
                    }
                    else
                    {
                        validEntry = true;
                    }
                } while (!validEntry);

                // ニックネームを取得 (Obtener apodo)
                Console.Write("ニックネーム: "); // Apodo:
                string animalNickname = Console.ReadLine()?.Trim();
                animalNickname = string.IsNullOrEmpty(animalNickname) ? "ニックネームなし" : animalNickname; // Sin apodo

                // 身体的特徴を取得 (Obtener descripción física)
                Console.Write("身体的特徴: "); // Descripción física:
                string animalPhysicalDescription = Console.ReadLine()?.Trim();
                animalPhysicalDescription = string.IsNullOrEmpty(animalPhysicalDescription) ? "未定" : animalPhysicalDescription; // Por determinar

                // 性格の説明を取得 (Obtener descripción de personalidad)
                Console.Write("性格の説明: "); // Descripción de personalidad:
                string animalPersonalityDescription = Console.ReadLine()?.Trim();
                animalPersonalityDescription = string.IsNullOrEmpty(animalPersonalityDescription) ? "未定" : animalPersonalityDescription; // Por determinar

                // 情報を希望の形式で保存 (Almacenar la información con el formato deseado)
                ourAnimals[nuevaPosicion, 0] = "ID #: " + animalID;
                ourAnimals[nuevaPosicion, 1] = "種類: " + animalSpecies;
                ourAnimals[nuevaPosicion, 2] = "年齢: " + animalAge;
                ourAnimals[nuevaPosicion, 3] = "ニックネーム: " + animalNickname;
                ourAnimals[nuevaPosicion, 4] = "身体的特徴: " + animalPhysicalDescription;
                ourAnimals[nuevaPosicion, 5] = "性格: " + animalPersonalityDescription;

                Console.WriteLine("\nペットが正常に追加されました！"); // ¡Mascota agregada exitosamente!

                if (petCount + 1 < maxPets)
                {
                    Console.WriteLine("\n次に何をしますか？"); // ¿Qué desea hacer ahora?
                    Console.WriteLine("1. 別のペットを追加"); // 1. Agregar otra mascota
                    Console.WriteLine("2. メインメニューに戻る"); // 2. Volver al menú principal
                    Console.Write("オプションを選択してください (1-2): "); // Seleccione una opción (1-2):

                    string opcionRegistro = Console.ReadLine()?.Trim();

                    if (opcionRegistro == "2")
                    {
                        break; // ループを終了し、メインメニューに戻る (Sale del bucle y vuelve al menú principal)
                    }
                    // 1を選択した場合、またはそれ以外の場合、ループを続行 (Si eligió 1 o cualquier otra cosa, continúa en el bucle)
                }
                else
                {
                    Console.WriteLine("\n最大ペット数に達しました！"); // ¡Hemos alcanzado el límite máximo de mascotas!
                    Console.WriteLine("Enterを押してメインメニューに戻ります..."); // Presione Enter para volver al menú principal...
                    Console.ReadLine();
                    break;
                }
            } while (true); // これで、制御されたbreakを持つ無限ループを使用する (Ahora usamos un bucle infinito con break controlado)

            break; // このbreakはswitch caseから抜け出す (Este break sale del switch case)

        // switchの残りのケース... (Resto de los casos del switch...)
    }
} while (menuSelection != "exit");