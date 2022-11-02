﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        
        public IViewComponentResult Invoke()
        {
            var list = fm.TGetList();
            return View(list);
        }
    }
}