open System.Text.RegularExpressions

let readLines = System.IO.File.ReadAllText("./input.txt")
let passportGroups = readLines.Split("\n\n")
let passportStrings = passportGroups
                      |> Seq.map(fun(a) -> a.Replace('\n', ' '))
let passportFields = passportStrings
                      |> Seq.map(fun(a) -> a.Split(' '))
let passportParts = passportFields
                              |> Seq.map(fun(a) -> a
                                                   |> Seq.map(fun(b) -> b.Split(':')))
let intRangeValidator input min max = let year = input |> int
                                      year >= min && year <= max

let regexValidator input pattern =
   let m = Regex.Match(input,pattern) 
   m.Success

let isRequiredPassportField (passportParts:string[]) = passportParts.[0] <> "cid"

let isValidPassportField (passportParts:string[]) =
    let field = passportParts.[0]
    let value = passportParts.[1]
    
    let result = match field with
                    | "byr" -> intRangeValidator value 1920 2002
                    | "iyr" -> intRangeValidator value 2010 2020
                    | "eyr" -> intRangeValidator value 2020 2030
                    | "hgt" -> let length = value.Length
                               let measurementType = value.[length - 2 .. length]
                               let measurementValue = value.[0 .. length - 3]

                               match measurementType with
                               | "cm" -> intRangeValidator measurementValue 150 193
                               | "in" -> intRangeValidator measurementValue 59 76
                               | _ -> false
                    | "hcl" -> regexValidator value "^#[0-9a-f]{6}$"
                    | "ecl" -> regexValidator value "^amb|blu|brn|gry|grn|hzl|oth$"
                    | "pid" -> regexValidator value "^[0-9]{9}$"
                    | _ -> false

    result

[<EntryPoint>]
let main argv =
    passportParts |> Seq.map(fun(g) -> g
                                        |> Seq.filter(isRequiredPassportField)
                                        |> Seq.map(isValidPassportField))
                             |> Seq.filter(fun(g) -> g |> Seq.length = 7)
                             |> Seq.filter(fun(g) -> (not (g |> (Seq.contains false))))
                             |> Seq.length
                             |> printfn "%A"
    0
 