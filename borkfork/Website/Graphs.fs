namespace Graphs
open IntelliFactory.WebSharper.Sitelets
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open System.Web
module ChartingSamples =


    open IntelliFactory.WebSharper.KendoUI

    [<JavaScript>]
    let Chart chartType stack = 
        Div []
        |>! OnAfterRender (fun el ->
            chart.Chart(
                el.Body ,
                chart.ChartConfiguration (
                    Theme = "default",
                    Title =
                        chart.ChartConfiguration.TitleConfiguration (
                            Text = "Internet Users"
                        ),
                    Legend =
                        chart.ChartConfiguration.LegendConfiguration (
                            Position = "bottom"
                        ),
                    ChartArea =
                        chart.ChartConfiguration.AreaConfiguration (
                            Background = ""
                        ),
                    SeriesDefaults =
                        chart.ChartConfiguration.SeriesDefaultConfiguration (
                            Type = chartType,
                            Stack = stack
                        ),
                    Series = [|
                        
                        chart.ChartConfiguration.SeriesConfiguration (
                            Name = "World",
                            Data = [|15.7 ; 16.7 ; 20. ; 23.5; 26.6|]
                        )

                        chart.ChartConfiguration.SeriesConfiguration (
                            Name = "United States",
                            Data = [|67.96 ; 68.93 ; 75. ; 74. ; 78.|]
                        )
                    |],
                    CategoryAxis =
                        chart.ChartConfiguration.AxisConfiguration (
                            Categories = [|"2005" ; "2006" ; "2007" ; "2008" ; "2009" |]
                        ),
                    ValueAxis =
                        chart.ChartConfiguration.AxisConfiguration (
                            Labels = 
                                chart.ChartConfiguration.LabelsConfiguration (
                                    Format = "{0}%"
                                )
                        ),
                    Tooltip =
                        chart.ChartConfiguration.TooltipConfiguration (
                            Visible = true,
                            Format = "{0}%"
                        ),

                    OnSeriesClick = fun args ->
                        let msg = args.Category + " : " + (string args.Value)
                        JavaScript.Alert msg
                )
            )
            |> ignore
            )