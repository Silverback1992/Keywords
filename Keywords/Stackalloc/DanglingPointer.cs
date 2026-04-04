namespace Keywords.Stackalloc;

public static class DanglingPointer
{
    public static unsafe void CreateDanglingPointer()
    {
        // We create an object on the managed heap. Unlike the stack, the heap is subject to garbage collection, which can move objects around in memory.
        // GC moves them around for defragmentation and to optimize memory usage.
        byte[] data = new byte[1024];
        data[0] = 99;

        // Declaring a raw pointer. Currently, it doesn't point to anything meaningful.
        int* p;

        // fixed: this is a contract with the GC. We are saying "Hey GC, I need to use this memory address directly, so please don't move it around until I'm done."
        fixed (byte* ptr = data)
        {
            // We copy the memory address of the first element of the byte array into our raw pointer.
            p = (int*)ptr;
        } // With the closing brace of the fixed block, we are telling the GC that we are done with the direct memory access. The GC is now free to move the byte array around in memory if it needs to.

        // At this point, the pointer 'p' is a dangling pointer. It still holds the memory address of the byte array as GC likely hasn't had a reason to move it yet.
        Console.WriteLine($"Value at address: {*p}");

        Console.ReadKey();

        // This loop is a "bait" for the GC. By iterating over a large range and printing values, we are creating enough activity that the GC might decide to run a collection cycle.
        foreach (var item in Enumerable.Range(1, 200000))
        {
            int x = item;
            Console.WriteLine($"Value is {x}");
        }


        // Forcing a garbage collection cycle. This is a way to increase the chances that the GC will move the byte array around in memory, which would make our pointer 'p' point to an invalid location.
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // Now we are asking the CPU to look at the address stored in 'p' and read the value there. Since 'p' is a dangling pointer, this can lead to undefined behavior.
        // It might print the original value (99), it might print garbage data, or it could even cause a crash if the memory has been reallocated for something else.
        Console.WriteLine($"Value at address: {*p}");
    }
}
