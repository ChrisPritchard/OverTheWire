#include <stdlib.h>

char shellcode[] = "\x31\xc0\xb0\x01\x31\xdb\xcd\x80";

int main()
{
    int (*ret)();
    ret = (int(*)())shellcode;

    (int)(*ret)();
    // exit(0);
}