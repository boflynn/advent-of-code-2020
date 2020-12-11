let readLines = System.IO.File.ReadAllText("./input.txt")
let answerGroups = readLines.Split("\n\n")
let groupPersonCounts = answerGroups |>
                                     Array.map(fun a -> a.Split("\n") |> Array.length)
let answerStrings = answerGroups
                      |> Seq.map(fun(a) -> a.Replace('\n', ' ').Replace(" ", ""))

[<EntryPoint>]
let main argv =
    let combined = answerStrings
                   |> Seq.zip groupPersonCounts
                   |> Seq.map(fun (a, b) -> let groups = b |> Seq.countBy (id)
                                            let allAnswered = groups |> Seq.filter(fun(c, count) -> count = a)

                                            allAnswered |> Seq.length
                   )

    combined |> Seq.sum |> printfn "%A"
    
    0
