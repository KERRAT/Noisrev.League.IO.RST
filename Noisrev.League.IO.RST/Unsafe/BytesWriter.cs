﻿/*
 * Copyright (c) 2021 - 2023 Noisrev
 * All rights reserved.
 *
 * This source code is distributed under an MIT license. 
 * LICENSE file in the root directory of this source tree.
 */

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Noisrev.League.IO.RST.Unsafe;

internal unsafe class BytesWriter
{
    private byte[] _buffer;
    private int _position;
    private int _length;

    public byte[] Buffer => _buffer;
    public int Position => _position;
    public int Length => _length;
    public int Capacity => _buffer.Length;

    private BytesWriter()
    {
        _buffer = new byte[4];
    }

    private BytesWriter(int capacity)
    {
        _buffer = new byte[capacity];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(bool value)
    => WriteByte((byte)(value ? 1 : 0));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(byte value)
    => WriteByte(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(sbyte value)
    => WriteByte((byte)value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(char[] ch)
    => Write(ch, Encoding.ASCII);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(char[] ch, Encoding encoding)
    => CoreceWrite(encoding.GetBytes(ch));

    public void Write(byte[] bytes) => CoreceWrite(bytes);

    public void Write(byte[] bytes, int index, int count) => CoreceWrite(bytes, index, count);

    public void Write(double value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }

    public void Write(short value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }

    public void Write(ushort value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }

    public void Write(int value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }
    public void Write(uint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }

    public void Write(long value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }

    public void Write(ulong value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }

    public void Write(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        MemoryMarshal.Write(buffer, ref value);
        CoreceWrite(buffer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(string value, bool writeEndChar = false)
    => Write(value, Encoding.Default, writeEndChar);

    public void Write(string value, Encoding encoding, bool writeEndChar = false)
    {
        var byteCount = encoding.GetByteCount(value);
        if (writeEndChar)
        {
            byteCount += 1;
        }

        var bytes = new byte[byteCount];
        encoding.GetBytes(value, 0, value.Length, bytes, 0);
        CoreceWrite(bytes);
    }

    public void WriteByte(byte value)
    {
        CheckOrResize(1);

        _buffer[_position++] = value;
        _length++;
    }

    private void CoreceWrite(ReadOnlySpan<byte> buffer)
    {
        var size = buffer.Length;
        CheckOrResize(size);

        var span = new Span<byte>(_buffer);
        buffer.CopyTo(span.Slice(_position, size));

        _position += size;
        _length += size;
    }

    private void CoreceWrite(ReadOnlySpan<byte> buffer, int index, int count)
    {
        var size = count;
        CheckOrResize(size);

        var span = new Span<byte>(_buffer);
        buffer.Slice(index, size).CopyTo(span.Slice(_position, size));

        _position += size;
        _length += size;
    }

    private void CheckOrResize(int bufferSize)
    {
        if (bufferSize > _buffer.Length - _length)
        {
            var capacity = _buffer.Length;
            var maxValue = Math.Max(bufferSize, capacity);
            var rentedSize = checked(capacity + maxValue);

            var span = new Span<byte>(_buffer, 0, _length);

            var newBuffer = new byte[rentedSize];
            var span2 = new Span<byte>(newBuffer);

            span.CopyTo(span2);
            _buffer = newBuffer;
        }
    }

    public static BytesWriter Create()
    {
        return new BytesWriter();
    }

    public static BytesWriter Create(int capacity)
    {
        return new BytesWriter(capacity);
    }
}
