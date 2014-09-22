open System.Diagnostics

[<EntryPoint>]
let main argv = 
    let n = int argv.[0]
    let sw = Stopwatch.StartNew()
    seq { for i in 1..n -> async { return i + i }}
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    sw.Stop()
    printfn "%d asyncs in %O (%f /sec)" n sw.Elapsed ((float n / float sw.ElapsedMilliseconds) * 1000.)
    0    
