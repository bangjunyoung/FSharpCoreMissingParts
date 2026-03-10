//
// Copyright 2026 Bang Jun-young
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
// 1. Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
// OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//

module FSharpCoreMissingParts.SpanTests

open System
open NUnit.Framework

[<Test>]
let ``stackalloc returns a span of the specified length`` () =
    let span = Span.stackalloc<int> 3
    span[0] <- 1
    span[1] <- 2
    span[2] <- 3
    Assert.That(span.Length, Is.EqualTo(3))
    Assert.That(span[0], Is.EqualTo(1))
    Assert.That(span[1], Is.EqualTo(2))
    Assert.That(span[2], Is.EqualTo(3))

[<Test>]
let ``stackalloc throws IndexOutOfRangeException if index is out of bounds`` () =
    Assert.That(Func<_>(fun () -> let span = Span.stackalloc<int> 4
                                  span[4] <- 42),
                Throws.InstanceOf<IndexOutOfRangeException>())

[<Test>]
let ``toReadOnlySpan returns a read-only span with the same contents`` () =
    let arr = [|1; 2; 3|]
    let span = Span arr
    span[0] <- 42
    let readOnlySpan = Span.toReadOnlySpan span
    Assert.That(readOnlySpan.Length, Is.EqualTo(3))
    Assert.That(readOnlySpan[0], Is.EqualTo(42))
    Assert.That(readOnlySpan[1], Is.EqualTo(2))
    Assert.That(readOnlySpan[2], Is.EqualTo(3))
