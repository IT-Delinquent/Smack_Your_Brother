using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.SaveGameOperations
{

    public class LoadData
    {

        public static List<GameSaveClass> CreateData(string json)
        {
            List<GameSaveClass> list = JsonConvert.DeserializeObject<List<GameSaveClass>>(json);

            return list;
        }
    }
}