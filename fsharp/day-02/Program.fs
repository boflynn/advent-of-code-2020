// // 6-7 z: dqzzzjbzz
type Password(input: string) =
    let input = input
    let parts = input.Split(':')
    let colonParts = parts.[0].Split(':')
    let spaceParts = colonParts.[0].Split(' ')
    let countParts = spaceParts.[0].Split('-')

    member this.Password = parts.[1]
    member this.MinCount = countParts.[0] |> int
    member this.MaxCount = countParts.[1] |> int
    member this.RequiredCharacter = spaceParts.[1].ToCharArray().[0]

    member this.IsValid() =
        let isValid =  Seq.toList this.Password
                        |> List.countBy(id)
                        |> List.filter(fun(a, b) -> a = this.RequiredCharacter && b >= this.MinCount && b <= this.MaxCount)
                        |> List.isEmpty = false
        
        isValid;

let readLines filePath = System.IO.File.ReadLines(filePath)

let parsePasswords = 
    let lines = readLines "./input.txt"
    let parts = lines |> Seq.map(Password)
    parts

[<EntryPoint>]
let main argv =
    let passwords = parsePasswords
    let count = parsePasswords |> Seq.filter(fun(a) -> (a.IsValid()))
                               |> Seq.length

    printf "%i" count
    0 // return an integer exit code