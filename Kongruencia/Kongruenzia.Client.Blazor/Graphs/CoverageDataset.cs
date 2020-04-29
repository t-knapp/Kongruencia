using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.LineChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruenzia.Client.Blazor.Graphs
{
    public class CoverageDataset
    {
        public static LineDataset<T> Create<T>(string label, ECoverageType type) where T : class
        {
            return new LineDataset<T>
            {
                BackgroundColor = ColorHelper.GetCoverageTypeColor(type),
                BorderColor = ColorHelper.GetCoverageTypeColor(type),
                Label = label,
                Fill = false,
                BorderWidth = 2,
                PointRadius = 3,
                PointBorderWidth = 1,
                SteppedLine = SteppedLine.Before,
            };
        }
    }
}
