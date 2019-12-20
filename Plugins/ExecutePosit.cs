using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;

namespace Plugins
{
    public class ExecutePosit : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Получить контекст выполнения от поставщика услуг
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            // Коллекция InputParameters содержит все данные, переданные в запросе
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                // Получить целевой объект из входных параметров
                Entity entity = (Entity)context.InputParameters["Target"];

                var position = entity.GetAttributeValue<string>("jobtitle");
                if (entity.LogicalName == "contact")
                {
                    //throw new InvalidPluginExecutionException($"Должность {position.Length}контакта не заполнена!");
                    //throw new InvalidPluginExecutionException((position=="").ToString()+position);
                    if ((position == null)||(position.Length == 0))
                    {
                        throw new InvalidPluginExecutionException($"Должность контакта не заполнена!");
                    } 
                }
            } 
        }
    }
}
