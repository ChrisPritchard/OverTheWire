#include <stdlib.h>

const char shellcode[] = "\x48\x31\xff\x48\x83\xc7\x03\x48\x31\xc0\x48\x83\xc0\x3c\x0f\x05";

int main()
{
    (*(void(*)())shellcode)();
    // exit(0);
}