let readLines = System.IO.File.ReadAllText("./input.txt")
let answerGroups = readLines.Split("\n\n")
let answerStrings = answerGroups
                      |> Seq.map(fun(a) -> a.Replace('\n', ' ').Replace(" ", ""))

[<EntryPoint>]
let main argv =
    answerStrings |> Seq.map(Seq.distinct)
                  |> Seq.map(Seq.length)
                  |> Seq.sum
                  |> printfn "%A"
    0
