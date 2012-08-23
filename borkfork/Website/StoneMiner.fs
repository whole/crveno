namespace StoneMiner
open borkData
open Commons
open HtmlAgilityPack
open System.Text.RegularExpressions

module FilterJobs =
       let getItems() = seq { for i in Connections.db.ONEPOST do
                                yield [i.Title; i.Link; i.Poslodavac; i.Mjesto_rada; i.Rok_za_prijavu] 
                          } 
                            // we remove duplicates... I don't know how expensive
                          //this operation is. I will calculate it eventually.
                                
       let items = getItems()
       let filterItems() = Set.ofSeq(items)

       // this is PRIMITIVE WAY of doing stuff... refactor later
 module Charts =

       
       let searchTerms = ["ASP.NET"; "sql"; "sql server"; "html"; "css"; "ORM"; "HTML"; "C#"]


       let getPosts() =  seq { for i in Connections.db.POSTRAWDATA do
                               yield [i.Id_of_post.ToString(); i.Link; i.RawData] 
                          }   
                       |> Seq.toList


     // for mojPosao rawData
       let getJobDetails text = 
            let html = new HtmlAgilityPack.HtmlDocument()
            html.LoadHtml(text)
            let parsedText = Regex.Split(html.GetElementbyId("job-detail").InnerText, " ")
            parsedText

       let matchQuery() = seq { let items = getPosts() //|> List.head
                              for post in items do
                                if post.[0] = "2" then
                                    let parsedText = getJobDetails(post.[2])
                                    for word in parsedText do
                                        for i in searchTerms do
                                                if word.ToLower() = i.ToLower() then
                                                    yield word.ToLower() }
                            |> Seq.toList
                          
                          



//       let pushPostContent = seq {
//                for i in filterItems do
//                    yield [i.[1]; i.[1] |> Parsing.http; ]  }
//                    
//        
//       let pushToDb (s: seq<string list>) = 
//             for i in s do
//                Connections.db.POSTRAWDATA.InsertOnSubmit( new Connections.dbSchema.ServiceTypes.POSTRAWDATA
//                    (
//                      Link         = i.[0],
//                      RawData      = i.[1],
//                      Id_of_post   = 2L
//                      )
//                    )
//                try
//                    Connections.db.DataContext.SubmitChanges()
//                    printfn "Successfully inserted new rows."
//                with
//                    | exn -> printfn "Exception:\n%s" exn.Message
//
