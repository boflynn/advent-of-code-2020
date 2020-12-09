let readLines filePath = System.IO.File.ReadLines(filePath)
let readArray filePath = readLines filePath |> Seq.map(fun(a) -> a.ToCharArray())
                                            |> Seq.toList

[<EntryPoint>]
let main argv =
    let array = readArray "./input.txt"
    let width = array.[0].Length

    let trees = array |> List.indexed
                |> List.filter (fun(a, b) -> b.[a * 3 % width] = '#')
                |> List.length

    printfn "%i" trees
    0