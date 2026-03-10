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

namespace FSharpCoreMissingParts

open System
open Microsoft.FSharp.NativeInterop

module Span =

    ///
    /// <summary>
    /// Allocates a block of memory on the stack and returns it as a span.
    /// The memory is automatically freed when the method returns.
    /// The type parameter 'T must be an unmanaged type.
    /// </summary>
    ///
    /// <param name="length">The number of elements to allocate.</param>
    ///
    /// <returns>A span representing the allocated memory.</returns>
    ///
    #nowarn "9"
    let inline stackalloc<'T when 'T : unmanaged> length =
        Span<'T>(NativePtr.toVoidPtr (NativePtr.stackalloc<'T> length), length)

    ///
    /// <summary>
    /// Converts a mutable span to a read-only span with the same contents.
    /// The resulting read-only span shares the same underlying memory as the input span,
    /// so changes to the input span will be reflected in the output span.
    /// </summary>
    ///
    /// <param name="span">The input mutable span.</param>
    ///
    /// <returns>A read-only span with the same contents as the input span.</returns>
    ///
    #nowarn "3391"
    let inline toReadOnlySpan<'T> (span: Span<'T>) : ReadOnlySpan<'T> = span
