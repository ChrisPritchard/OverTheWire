open System
open System.Text
open System.IO

let b64decode s =
    let bytes = Convert.FromBase64String s
    Encoding.ASCII.GetString bytes

let rot n (s: string) =
    let minA = int 'A'
    let maxZ = int 'Z'
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
    let englishFrequencyOrder = "etaoinshrdlcumwfgypbvkjxqz".ToUpper().ToCharArray ()
    let sourcesFrequencyOrder = 
        (sources |> Seq.map File.ReadAllText |> String.concat "").Replace(" ", "")
        |> Seq.countBy id |> Seq.sortByDescending snd |> Seq.map fst |> Seq.toArray
    data.Replace(" ", "").ToCharArray ()
    |> Array.map (fun c -> 
        let index = Array.findIndex ((=) c) sourcesFrequencyOrder
        englishFrequencyOrder.[index])
    |> fun (ca: char []) -> String(ca)

// Krypton 0:
printfn "Krypton 1: %s" <| b64decode "S1JZUFRPTklTR1JFQVQ="

// Krypton 1:
printfn "Krypton 2: %s" <| rot 13 "YRIRY GJB CNFFJBEQ EBGGRA"

// Krypton 2:
printfn "Krypton 3: %s" <| rot -12 "OMQEMDUEQMEK"

// Krypton 3:
let decode = freqDecode ["./krypton/found1"; "./krypton/found2"; "./krypton/found3"]
printfn "Krypton 4: %s" <| decode "KSVVW BGSJD SVSIS VXBMN YQUUK BNWCU ANMJS"