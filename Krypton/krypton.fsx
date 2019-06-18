open System
open System.Text
open System.IO

let dictionary = File.ReadAllLines "./Krypton/dictionary.txt"
let englishFrequencyOrder = "eatsorinhcldupgfwymbkvjxqz".ToUpper().ToCharArray ()

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

let freqDecode sources (cipher: string) =
    let sourcesFrequencyOrder = 
        (sources |> Seq.map File.ReadAllText |> String.concat "").Replace(" ", "")
        |> Seq.countBy id |> Seq.sortByDescending snd |> Seq.map fst |> Seq.toArray
    cipher.Replace(" ", "").ToCharArray ()
    |> Array.map (fun c -> 
        let index = Array.findIndex ((=) c) sourcesFrequencyOrder
        englishFrequencyOrder.[index])
    |> String

let vigenèreDecode (key: string) (cipher: string) =
    cipher.Replace(" ", "").ToCharArray() 
    |> Array.mapi (fun i c ->
        let keyChar = int key.[i % key.Length] - minA
        rot -keyChar (string c) |> char)
    |> String

let vigenèreHack sources keyLength (cipher: string) =
    let subStringsFor source =
        (File.ReadAllText source).Replace (" ", "")
        |> Seq.indexed
        |> Seq.groupBy (fun (i, _) -> i % 6)
        |> Seq.map (snd >> Seq.map snd >> Seq.toArray >> String)
    let isLikely keyChar (subString: string) = 
        rot -(int keyChar) subString 
        |> Seq.countBy id
        |> Map.ofSeq
        |> fun m -> m.ContainsKey 'E' && float m.['E'] / float subString.Length > 0.12
    let candidatesFor subString =
        ['A'..'Z'] |> List.filter (fun c -> isLikely c subString)
    ""
    
    
// Krypton 0:
printfn "Krypton 1: %s" <| b64decode "S1JZUFRPTklTR1JFQVQ="

// Krypton 1:
printfn "Krypton 2: %s" <| rot 13 "YRIRY GJB CNFFJBEQ EBGGRA"

// Krypton 2:
printfn "Krypton 3: %s" <| rot -12 "OMQEMDUEQMEK"

// Krypton 3:
let sources3 = ["./Krypton/krypton03found/found1"; "./Krypton/krypton03found/found2"; "./Krypton/krypton03found/found3"]
printfn "Krypton 4: %s" <| freqDecode sources3 "KSVVW BGSJD SVSIS VXBMN YQUUK BNWCU ANMJS"

// Krypton 4:
let sources4 = ["./Krypton/krypton04found/found1"; "./Krypton/krypton04found/found2"]
printfn "Krypton 5 options:\r\n%A" <| vigenèreHack sources4 6 "HCIKV RJOX"