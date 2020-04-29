using ChartJs.Blazor.ChartJS.Common.Axes;
using ChartJs.Blazor.ChartJS.Common.Axes.Ticks;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Handlers;
using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.ChartJS.Common.Time;
using ChartJs.Blazor.ChartJS.LineChart;
using System.Collections.Generic;

namespace Kongruenzia.Client.Blazor.Graphs
{
    public class LineGraphConfig
    {
        public static LineConfig Create(string caption)
        {
            return new LineConfig
            {
                Options = new LineOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = caption
                    },
                    Legend = new Legend
                    {
                        Position = Position.Top,
                        Labels = new LegendLabelConfiguration
                        {
                            UsePointStyle = false
                        }
                    },
                    Tooltips = new Tooltips
                    {
                        Mode = InteractionMode.Index,
                        Intersect = false
                    },
                    Scales = new Scales
                    {
                        xAxes = new List<CartesianAxis>
                        {
                            new TimeAxis
                            {
                                Distribution = TimeDistribution.Linear,
                                Ticks = new TimeTicks
                                {
                                    Source = TickSource.Data
                                },
                                Time = new TimeOptions
                                {
                                    Unit = TimeMeasurement.Millisecond,
                                    Round = TimeMeasurement.Millisecond,
                                    TooltipFormat = "DD.MM.YYYY HH:mm:ss",
                                    DisplayFormats = TimeDisplayFormats.DE_CH
                                },
                                ScaleLabel = new ScaleLabel
                                {
                                    LabelString = "Time"
                                }
                            }
                        }
                    },
                    Hover = new LineOptionsHover
                    {
                        Intersect = true,
                        Mode = InteractionMode.Y
                    }
                }
            };
        }
    }
}
