#include <stdlib.h>

char shellcode[] = "\x48\xc7\xc7\x02\x48\xc7\xc0\x3c\x0f\x05";

int main()
{
    int (*ret)();
    ret = (int(*)())shellcode;

    (int)(*ret)();
    // exit(0);
}