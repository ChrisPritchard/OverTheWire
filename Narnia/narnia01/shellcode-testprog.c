#include <stdlib.h>

// \x48\x31\xff\x48\x83\xc7\x02\x48\x31\xc0\x48\x83\xc0\x3c\x0f\x05

char shellcode[] = "\x48\x31\xff\x48\x83\xc7\x02\x48\x31\xc0\x48\x83\xc0\x3c\x0f\x05";

int main()
{
    int (*ret)();
    ret = (int(*)())shellcode;

    (int)(*ret)();
    // exit(0);
}