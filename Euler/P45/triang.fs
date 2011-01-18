///Project Euler Problem 45
///Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
///Triangle 	  	Tn=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
///Pentagonal 	  	Pn=n(3n-1)/2 	  	1, 5, 12, 22, 35, ...
///Hexagonal 	  	Hn=n(2n-1) 	  	    1, 6, 15, 28, 45, ...
///
///It can be verified that T285 = P165 = H143 = 40755.
///
///Find the next triangle number that is also pentagonal and hexagonal.
//-----------------------------------------------------------------------
// <copyright file="triang.fs" >
//     Copyright � Cesar Mendoza. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
open System
open System.Collections.Generic

let triangular n = (n * (n + 1L))/2L
let pentagonal n = (n * ((3L * n) - 1L))/2L
let hexagonal  n = n * ((2L * n) - 1L)

// (triangular 285L, pentagonal 165L, hexagonal 143L) |> printfn "%A"
// (pentagonal 166L, hexagonal 144L) |> printfn "%A"

let dict = new Dictionary<_,_>()

let updateDict k = 
    let found,count = dict.TryGetValue(k)
    if found then
        dict.Remove(k) |> ignore
        dict.Add(k,count + 1) |> ignore
    else
        dict.Add(k,1) |> ignore
        

for i in 286L .. 100000L do
    let t = triangular i
    updateDict t

for i in 166L .. 50000L do
    let p = pentagonal i
    updateDict p
    
for i in 144L .. 50000L do
    let h = hexagonal i
    updateDict h

let solution = dict |> Seq.find (fun kvp -> kvp.Value = 3) |> (fun kvp -> kvp.Key)
solution |> printfn "solution: %d"

Console.ReadKey(true) |> ignore