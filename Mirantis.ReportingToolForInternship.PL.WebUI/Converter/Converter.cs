namespace Mirantis.ReportingToolForInternship.PL.WebUI.Converter
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class Converter
    {
        public static IList<ErrorVM> GetErrorList(ModelStateDictionary dictionary)
        {
            List<ErrorVM> errors = new List<ErrorVM>();
            foreach(var item in dictionary)
            {
                foreach (var error in item.Value.Errors)
                {
                    errors.Add(new ErrorVM() { Description = error.ErrorMessage });
                }
            }

            return errors;
        }
    }
}