﻿#nullable disable // suppress the null warning on code
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additonal Namespace
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
#endregion

namespace ChinookSystem.BLL
{
    // this class needs to be accessed by an "outside user" (WebApp)
    // therefore the class needs to be public
    public class AboutService
    {
        #region Constructor and Context Dependency
        private readonly ChinookContext _context;

        internal AboutService(ChinookContext context)
        {
            _context = context;
        }
        #endregion

        #region Services
        public DbVersionInfo GetDbVersion()
        {
            DbVersionInfo info = _context.DbVersions
                                    .Select(x => new DbVersionInfo
                                    {
                                        Major = x.Major,
                                        Minor = x.Minor,
                                        Build = x.Build,
                                        ReleaseDate = x.ReleaseDate
                                    })
                                    .SingleOrDefault();
            return info;
        }

        public List<NamedColors> ListHMTLColors()
        {
            List<NamedColors> colors = new List<NamedColors> {
                 new NamedColors("rgb(255, 0, 0)", "#FF0000", "RED", 1, true),
                new NamedColors("rgb(255, 192, 203)", "#FFC0CB", "PINK", 1, true),
                new NamedColors("rgb(255, 165, 0)", "#FFA500", "ORANGE", 1, false),
                new NamedColors("rgb(255, 255, 0)", "#FFFF00", "YELLOW", 1, true),
                new NamedColors("rgb(128, 0, 128)", "#800080", "PURPLE", 1, true),
                new NamedColors("rgb(0, 128, 0)", "#008000", "GREEN", 2, true),
                new NamedColors("rgb(0, 0, 255)", "#0000FF", "BLUE", 3, false),
                new NamedColors("rgb(165, 42, 42)", "#A52A2A", "BROWN", 4, false),
                new NamedColors("rgb(255, 255, 255)", "#FFFFFF", "WHITE", 4, true),
                new NamedColors("rgb(128, 128, 128)", "#808080", "GRAY", 4, true)
                };
            return colors;
        }

        public List<SelectionList> ColorWarmth()
        {
            List<SelectionList> warmth = new List<SelectionList>
            {
                new SelectionList(){ValueId = 1, DisplayText = "Hot" },
                new SelectionList(){ValueId = 2, DisplayText = "Warm" },
                new SelectionList(){ValueId = 3, DisplayText = "Cool" },
                new SelectionList(){ValueId = 4, DisplayText = "Cold" }

            };
            return warmth;
        }
        #endregion
    }
}
