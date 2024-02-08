using MySqlConnector;
using System.Data;
using System.Security.Cryptography;
using System.Text;


string m_strMySQLConnectionString;
m_strMySQLConnectionString = "server=localhost;userid=root;password=root;database=db_inde;port=6033";

DisplayMainMenu();

void DisplayMainMenu()
{
    while (true)
    {
        Console.Title = "ERP - Menu";
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;

        int optionWelcome = 1;
        bool isSelectedWelcome = false;
        string colorWelcome = "    \u001B[32m";

        while (!isSelectedWelcome)
        {
            int topWelcome = Console.WindowHeight / 2;

            string welcome = @"
  ___ _  _ ___  ___ 
 |_ _| \| |   \| __|
  | || .` | |) | _| 
 |___|_|\_|___/|___|
                    
                           
";

            string[] welcomeLines = welcome.Split("\n");
            int welcomeHeight = Console.WindowHeight / 2 - 6;

            for (int i = 0; i < welcomeLines.Length; i++)
            {
                Console.CursorLeft = Console.WindowWidth / 2 - (welcomeLines[i].Length / 2 - 4);
                Console.CursorTop = welcomeHeight + i;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(welcomeLines[i]);
            }

            Console.SetCursorPosition((Console.WindowWidth - "Films".Length) / 2, topWelcome + 3);
            Console.WriteLine($"{(optionWelcome == 1 ? colorWelcome : "    ")}INDE\u001b[0m");

            Console.SetCursorPosition((Console.WindowWidth - "Indispo".Length) / 2, topWelcome + 4);
            Console.WriteLine($"{(optionWelcome == 2 ? colorWelcome : "    ")}Indispo\u001b[0m");

            Console.SetCursorPosition((Console.WindowWidth - "Indispo".Length) / 2, topWelcome + 5);
            Console.WriteLine($"{(optionWelcome == 3 ? colorWelcome : "    ")}Indispo\u001b[0m");

            Console.SetCursorPosition((Console.WindowWidth - "Quitter".Length) / 2, topWelcome + 6);
            Console.WriteLine($"{(optionWelcome == 4 ? colorWelcome : "    ")}Quitter\u001b[0m");

            var keyWelcome = Console.ReadKey(true);


            switch (keyWelcome.Key)
            {
                case ConsoleKey.UpArrow:
                    optionWelcome = optionWelcome == 1 ? 4 : optionWelcome - 1;
                    break;

                case ConsoleKey.DownArrow:
                    optionWelcome = optionWelcome == 4 ? 1 : optionWelcome + 1;
                    break;

                case ConsoleKey.Enter:
                    isSelectedWelcome = true;
                    break;
            }
        }

        if (optionWelcome == 1)
        {
            FilmCSV();
        }
        else if (optionWelcome == 2)
        {

        }
        else if (optionWelcome == 3)
        {

        }
        else if (optionWelcome == 4)
        {
       
        }
    }
}

void FilmCSV()
{

    using (var mysqlconnection = new MySqlConnection(m_strMySQLConnectionString))
    {
        mysqlconnection.Open();
        int added = 0;

        bool first = true;
        foreach (string line in File.ReadAllLines(
                     @"C:\Users\pz43zwu\Desktop\Mandat_Test_Leonardo\msig-prog-eval3-erp1-data.csv"))
        {
            if (first == true)
            {
                first = false;
            }
            else
            {
                var columns = line.Split(";");
                string rating = columns[0].ToLower();
                string company_name = columns[1].ToLower();
                string job_title = columns[2].ToLower();
                string salary = columns[3].ToLower();
                string salaries_reported = columns[4].ToLower();
                string location = columns[5].ToLower();
                string salary_chf = columns[6].ToLower();



                string image = job_title.ToLower();



                if (salaries_reported.Contains("3"))
                {
                    

                    if (job_title.Contains("android"))
                    {
                        Console.WriteLine(image + "droid.png");
                        string imagejpg = image + "droid.png";

                        // int disponibilite = 1;
                        string sql =
                                    @$"insert into informations (rating, company_name, job_title, salary, salaries_reported, location, salary_chf, image)
                        values ('{rating}','{company_name}','{job_title}','{salary}','{salaries_reported}','{location}','{salary_chf}','{imagejpg}')";
                                using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.CommandTimeout = 300;
                                    cmd.CommandText = sql;

                                    added = added + cmd.ExecuteNonQuery();
                                }

                            }

                    }

                    else
                    {
                        if (job_title.Contains("python"))
                        {
                            Console.WriteLine(image + "python.png");
                            string imagepng = image + "python.png";

                        // int disponibilite = 1;
                        string sql =
                                @$"insert into informations (rating, company_name, job_title, salary, salaries_reported, location, salary_chf, image)
                        values ('{rating}','{company_name}','{job_title}','{salary}','{salaries_reported}','{location}','{salary_chf}','{imagepng}')";
                        using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 300;
                            cmd.CommandText = sql;

                            added = added + cmd.ExecuteNonQuery();
                        }

                    }
                



                        else
                        {
                            if (job_title.Contains("ios"))
                            {
                                Console.WriteLine(image + "mac.png");
                                string imagepng = image + "mac.png";

                            // int disponibilite = 1;
                            string sql =
                           @$"insert into informations (rating, company_name, job_title, salary, salaries_reported, location, salary_chf, image)
                        values ('{rating}','{company_name}','{job_title}','{salary}','{salaries_reported}','{location}','{salary_chf}','{imagepng}')";
                            using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandTimeout = 300;
                                cmd.CommandText = sql;

                                added = added + cmd.ExecuteNonQuery();
                            }
                        }

                            else
                            {
                                if (job_title.Contains("sde"))
                                {
                                    Console.WriteLine(image + "dev.png");
                                    string imagepng = image + "dev.png";

                                // int disponibilite = 1;
                                string sql =
                           @$"insert into informations (rating, company_name, job_title, salary, salaries_reported, location, salary_chf, image)
                        values ('{rating}','{company_name}','{job_title}','{salary}','{salaries_reported}','{location}','{salary_chf}','{imagepng}')";
                                using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.CommandTimeout = 300;
                                    cmd.CommandText = sql;

                                    added = added + cmd.ExecuteNonQuery();
                                }
                            }

                                else
                                {

                                    if (!job_title.Contains("python") || !job_title.Contains("android") || !job_title.Contains("ios") || !job_title.Contains("sde"))
                                    {
                                        Console.WriteLine(image + "empty.png");
                                        string imagepng = image + "empty.png";

                                    // int disponibilite = 1;
                                    string sql =
                           @$"insert into informations (rating, company_name, job_title, salary, salaries_reported, location, salary_chf, image)
                        values ('{rating}','{company_name}','{job_title}','{salary}','{salaries_reported}','{location}','{salary_chf}','{imagepng}')";
                                    using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                                    {
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandTimeout = 300;
                                        cmd.CommandText = sql;

                                        added = added + cmd.ExecuteNonQuery();
                                    }
                                }
                                }
                            }
                        }
                    }
                








                                

                            //   else
                            // {
                            //   Console.WriteLine("Pas assez de salaires reportés");
                            //}





                            // Console.WriteLine(password);
                        }

                    }

                    mysqlconnection.Close();

                    Console.WriteLine($"Added {added} records...");


                }

                
            }
            Console.ReadLine();

            string PasswordGenerate(int Lenght)
            {
                Random random = new Random();

                string LimitCharacter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string password = string.Empty;

                for (int i = 0; i < Lenght; i++)
                {
                    int index = random.Next(LimitCharacter.Length);
                    password += LimitCharacter[index];
                }

                return password;
            }

            string HashPassword(string input)
            {
                using (var hashGenerator = SHA256.Create())
                {
                    var hash = hashGenerator.ComputeHash(Encoding.Default.GetBytes(input));
                    return BitConverter.ToString(hash);
                }
            }

            void Exitprogram()
{
    Console.Clear();
    Console.Title = "Inde - Quit";

    Console.ForegroundColor = ConsoleColor.White;

    Console.CursorVisible = false;
    string goodbyeText = @"
     █████  ██    ██     ██████  ███████ ██    ██  ██████  ██ ██████
    ██   ██ ██    ██     ██   ██ ██      ██    ██ ██    ██ ██ ██   ██
    ███████ ██    ██     ██████  █████   ██    ██ ██    ██ ██ ██████
    ██   ██ ██    ██     ██   ██ ██       ██  ██  ██    ██ ██ ██   ██
    ██   ██  ██████      ██   ██ ███████   ████    ██████  ██ ██   ██
    ";
    string[] goodbyeScreen = goodbyeText.Split("\n");
    int goodbyeScreenHeight = Console.WindowHeight / 2 - 6;

    for (int i = 0; i < goodbyeScreen.Length; i++)
    {
        Console.CursorLeft = Console.WindowWidth / 2 - (goodbyeScreen[i].Length / 2 - 2);
        Console.CursorTop = goodbyeScreenHeight + i;
        Console.WriteLine(goodbyeScreen[i]);
    }

    Thread.Sleep(100);
    Environment.Exit(0);
}
          