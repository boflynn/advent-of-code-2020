let readLines = System.IO.File.ReadAllText("./input.txt")
let passportGroups = readLines.Split("\n\n")
let passportStrings = passportGroups
                      |> Seq.map(fun(a) -> a.Replace('\n', ' '))
let passportFields = passportStrings
                      |> Seq.map(fun(a) -> a.Split(' '))
let passportParts = passportFields
                              |> Seq.map(fun(a) -> a
                                                   |> Seq.map(fun(b) -> b.Split(':')))
[<EntryPoint>]
let main argv =
    passportParts |> Seq.map(fun(g) -> g |> Seq.filter(fun(a) -> (not (Array.contains "cid" a))))
                             |> Seq.filter(fun(g) -> (g |> Seq.length) = 7)
                             |> Seq.length
                             |> printfn "%A"

    0
 