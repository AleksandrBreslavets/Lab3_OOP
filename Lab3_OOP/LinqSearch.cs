using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP
{
    internal class LinqSearch
    {
        private bool IsValidPickerValue(string workValue, string criteriaValue)
        {
            return string.IsNullOrEmpty(criteriaValue) || workValue.Equals(criteriaValue);
        }

        public void Search(SearchCriteria criteria, ObservableCollection<ScientificWork> data, ObservableCollection<ScientificWork> results)
        {
            var works = (from work in data
                        where(
                         IsValidPickerValue(work.AuthorName, criteria.AuthorName) &&
                         IsValidPickerValue(work.Faculty, criteria.Faculty) &&
                         IsValidPickerValue(work.CustomerName, criteria.CustomerName) &&
                         IsValidPickerValue(work.Branch, criteria.Branch)
                        )
                        select work).ToList();

            results.Clear();
            foreach (ScientificWork work in works)
            {
                results.Add(work);
            }
        }
    }
}
