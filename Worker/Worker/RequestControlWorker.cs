using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Worker.Data;
using Worker.Model;

namespace Worker.Worker
{
    public class RequestControlWorker : BackgroundService
    {
        private readonly FoodData _data;
        public int dataCount;
        private string path;

        public RequestControlWorker(FoodData data)
        {
            _data = data;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            dataCount = _data._foodData.Count;
            while (!stoppingToken.IsCancellationRequested)
            {
               
                if(dataCount != _data._foodData.Count)
                {
                        path = @"C:\Users\Ozgur\source\repos\WorkerService\Worker\FoodData.json";
                        if (!File.Exists(path))
                        {

                            using (TextWriter tw = File.CreateText(path))
                            {
                                var json = JsonConvert.SerializeObject(_data._foodData);
                                tw.WriteLine(json);
                            }
                        }
                        else
                        {
                            using (StreamReader sr = File.OpenText(path))
                            {
                                var json = sr.ReadLine();
                                var deJSON = JsonConvert.DeserializeObject<List<Food>>(json);
                                _data._foodData = deJSON;
                            }
                        }

                    dataCount = _data._foodData.Count;
                    
                }

                await Task.Delay(1000);
            }
        }
    }
}
