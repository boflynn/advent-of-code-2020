let readLines filePath = System.IO.File.ReadLines(filePath)
let readArray filePath = readLines filePath |> Seq.map(fun(a) -> a.ToCharArray())
                                            |> Seq.toList

let listMultiplication numbers = numbers |> List.fold (*) 1L

[<EntryPoint>]
let main argv =
    let array = readArray "./input.txt"
    let width = array.[0].Length
    let patterns = [(1, 1); (1, 3); (1, 5); (1, 7); (2, 1)]

    let treeCounts = patterns |> List.map(fun(pattern) -> 
        let down = fst pattern
        let right = snd pattern

        let treeCount = array |> List.indexed
                              |> List.filter (fun(a, b) -> a % down = 0 && b.[a / down * right % width] = '#')
                              |> List.length
                              |> int64

        treeCount
    )

    let result = listMultiplication treeCounts

    printfn "%u" result
    0