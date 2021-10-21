using Aoutontification.Data.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aoutontification.Pages
{

    public class CounterViewMode: ComponentBase
    {
        public Account Data = new Account();
        public List<Account> Spisok = new List<Account>();
        public string Login(Account param1)
        {
            string json = File.ReadAllText(@"C:\Users\stellpro\Desktop\database.json");
            Spisok = JsonSerializer.Deserialize<List <Account>>(json);
            for (int i = 0; i < Spisok.Count; i++)
            {
                if ((param1.EmailAdress == Spisok[i].EmailAdress) && (param1.Password == Spisok[i].Password))
                {
                    return "Access";
                }
                else
                {
                    return "Incorrect Data";
                }

            }

            return "Incorrect Data";
        }
        public void Reg(Account param1)
        {
            for (int i = 0; i < Spisok.Count; i++)
            {
                if (param1 == Spisok[i])
                {
                    break;
                }
                else
                {
                    Spisok.Add(param1);
                }
             }
            string json = JsonSerializer.Serialize(Spisok);
            File.WriteAllText(@"C:\Users\stellpro\Desktop\database.json", json);
            StateHasChanged();
        }
        public bool Flag = false;
        public bool ChangeFlag()
        {
            if (Flag == false)
            {
                return Flag = true;
            }
            else
            {
                return Flag = false;
            }
        }
    }
}
