using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;

namespace Plugins
{
    public class AddEmail : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Получить контекст выполнения от поставщика услуг
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            // Коллекция InputParameters содержит все данные, переданные в запросе
            Entity entity = (Entity)context.InputParameters["Target"];
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                
                var email = entity.GetAttributeValue<string>("emailaddress1");
                if (entity.LogicalName == "contact")
                {
                    //throw new InvalidPluginExecutionException((str==null).ToString());

                    if ((email == null)||(email.Length == 0))
                    {
                        
                        var contact = new Entity("contact");
                        contact.Id = entity.Id;
                        //throw new InvalidPluginExecutionException($"Почта контакта {contact.Id}не заполнена!");
                        contact["emailaddress1"] = "jfjjdf@gnjfdk.tri";
                        service.Update(contact);
                    }

                }
            }
        }
    }
}
