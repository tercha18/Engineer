using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Models.Api.TrainingPlan
{
    public class SelectItemModel<T>
    {
        public SelectItemModel()
        {
        }

        public SelectItemModel(T key, string value)
        {
            Key = key;
            Value = value;
        }

        public T Key { get; set; }
        public string Value { get; set; }
    }
}
