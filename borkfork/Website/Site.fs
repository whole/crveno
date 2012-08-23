namespace Website

open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets

open StoneMiner

type Action =
    | Home
    | About

    //tralala
    
module Skin =
    open System.Web

    let TemplateLoadFrequency =
        #if DEBUG
        Content.Template.PerRequest
        #else
        Content.Template.Once
        #endif

    type Page =
        {
            Title : string
            Body : list<Content.HtmlElement>
        }

    let MainTemplate =
        let path = HttpContext.Current.Server.MapPath("~/Main.html")
        Content.Template<Page>(path, TemplateLoadFrequency)
            .With("title", fun x -> x.Title)
            .With("body", fun x -> x.Body)

    let WithTemplate title body: Content<Action> =
        Content.WithTemplate MainTemplate <| fun context ->
            {
                Title = title
                Body = body context
            }

module Site =

    let ( => ) text url =
        A [HRef url] -< [Text text]

    let Links (ctx: Context<Action>) =
        UL [
            LI ["Home" => ctx.Link Home]
            LI ["About" => ctx.Link About]
        ]

    let HomePage =
        Skin.WithTemplate "HomePage" <| fun ctx ->
            [
                Div [Text "HOME"]
                Links ctx
            ]

                
    let JobsPage = 
        Skin.WithTemplate "Jobs" <| fun ctx ->

                      
//                      <div class="spa-shell-modal">
//                    <div id="content">
//                        <div id="jobs-content">
//                            <div id="jobslist" class="main">
//                                <div data-hole="body">
//            Div [Class "spa-shell-modal"] -< 
//                [
//                Div [Id "content"] -< 
//                    [
//                        Div [Id "jobs-content"] -< 
//                        [ 
//                            Div [Id "jobslist"] -< 
//                            [ 
                  [
                    Div [Class "spa-shell-main-content"] -< 
                    [  
                      Div [Class "spa-shell-modal"] -< 
                      [
                        let items = FilterJobs.filterItems()
                        for i in items -> 
                        Div [Class "job"] -< 
                        [ 
                                A [Class "title"]       -< [HRef i.[1]] -< [ Text i.[0]] 
                                P [Class "posted top"]  -< [ Text i.[4] ]
                                P [Class "location"]    -< [ Text i.[3] ]
                                P [Class "employer"]    -< [ Text i.[2] ]
                        ]
                      ]
                    ]
                      
                    Div [Class "spa-shell-main-nav"] -< 
                    [ 
                        new KendoUIChartingViewer()
                    ]
                ]

      

      /// A sidebar
    let ClockPage : Content<Action> =
            Skin.WithTemplate "Clock" <| fun ctx ->
           
                       [
                        Div [Class "spa-shell-main-nav"] -< 
                         [ 
                           new KendoUIChartingViewer()
                         ]
                ]

                    
     
    let AboutPage =
        Skin.WithTemplate "AboutPage" <| fun ctx ->
            [
                Div [Text "ABOUT"]
                Links ctx
            ]

    let Main =
        // pullData.FlowControl.updateDb();
        let r = StoneMiner.Charts.matchQuery()
        Sitelet.Sum [
            Sitelet.Content "/" Home JobsPage //ClockPage
            //Sitelet.Content "/About" About AboutPage
        ]

type Website() =
    interface IWebsite<Action> with
        member this.Sitelet = Site.Main
        member this.Actions = [Home; About]

[<assembly: WebsiteAttribute(typeof<Website>)>]
do ()
