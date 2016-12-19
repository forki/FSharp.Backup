module Option
    let either f none = function
        | Some x -> f x
        | None -> none
