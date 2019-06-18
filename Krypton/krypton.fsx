open System
open System.Text
open System.IO

let dictionary = File.ReadAllLines "./Krypton/dictionary.txt"

let b64decode s =
    let bytes = Convert.FromBase64String s
    Encoding.ASCII.GetString bytes

let minA = int 'A'
let maxZ = int 'Z'

let rot n (s: string) =
    let buffer = s.ToCharArray()
    for i in [0..buffer.Length - 1] do
        buffer.[i] <-
            let c = int buffer.[i]
            if c < minA || c > maxZ then buffer.[i]
            else
                let rotated = c + n
                let bound = 
                    if rotated > maxZ 
                    then rotated - 26 
                    elif rotated < minA 
                    then maxZ - (minA - (rotated + 1))
                    else rotated
                char bound
    String(buffer)

let freqDecode sources (data: string) =
    let englishFrequencyOrder = "eatsorinhcldupgfwymbkvjxqz".ToUpper().ToCharArray ()
    let sourcesFrequencyOrder = 
        (sources |> Seq.map File.ReadAllText |> String.concat "").Replace(" ", "")
        |> Seq.countBy id |> Seq.sortByDescending snd |> Seq.map fst |> Seq.toArray
    data.Replace(" ", "").ToCharArray ()
    |> Array.map (fun c -> 
        let index = Array.findIndex ((=) c) sourcesFrequencyOrder
        englishFrequencyOrder.[index])
    |> fun (ca: char []) -> String(ca)

let vigenèreDictionaryAttack keyLength (data: string) =
    let concatted = data.Replace (" ", "")
    let decode (key: string) =
        concatted.ToCharArray ()
        |> Array.mapi (fun i c -> 
            let res = int c - int (key.[i % keyLength])
            if res < minA then char (maxZ - (minA - (res + 1)))
            else char res)
        |> String
    
    dictionary 
    |> Array.filter (fun s -> s.Length = keyLength)
    |> Array.map decode
    |> Array.filter (fun decoded -> dictionary |> Array.exists decoded.Contains)

// Krypton 0:
printfn "Krypton 1: %s" <| b64decode "S1JZUFRPTklTR1JFQVQ="

// Krypton 1:
printfn "Krypton 2: %s" <| rot 13 "YRIRY GJB CNFFJBEQ EBGGRA"

// Krypton 2:
printfn "Krypton 3: %s" <| rot -12 "OMQEMDUEQMEK"

// Krypton 3:
let decode = freqDecode ["./Krypton/krypton03found/found1"; "./Krypton/krypton03found/found2"; "./Krypton/krypton03found/found3"]
printfn "Krypton 4: %s" <| decode "KSVVW BGSJD SVSIS VXBMN YQUUK BNWCU ANMJS"

// Krypton 4:
printfn "Krypton 5 options:\r\n%A" <| vigenèreDictionaryAttack 6 "HCIKV RJOX"