﻿using StudentSystem2016.Models;
using StudentSystem2016.Servises.ProjectServise;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class GenericSelectedList<T> where T : BaseModel, new()
    {
        private EncriptServises _encript = new EncriptServises();
        public IEnumerable<SelectListItem> GetSelectedListIthem(List<T> result)
        {
            var selectedList = new List<SelectListItem>();
            for (int i = -1; i < result.Count; i++)
            {
                if (i == -1)
                {
                    selectedList.Add(new SelectListItem
                    {
                        Value = "-1",
                        Text = "Please select item......",
                    });
                }
                else
                {
                    selectedList.Add(new SelectListItem
                    {
                        Value = result[i].ID.ToString(),
                        Text = result[i].Name.ToString()
                    });
                }
            }

            return selectedList;
        }

        public IEnumerable<SelectListItem> GetSelectedListIthemQuantity(int quantity)
        {
            var selectedList = new List<SelectListItem>();
            for (int i = 1; i < quantity + 1; i++)
            {

                selectedList.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });

            }
            return selectedList;
        }
    }

}
