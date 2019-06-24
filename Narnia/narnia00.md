# Narnia 0

Password: `narnia0`

The C code is as follows (stripped license for brevity):

```c
#include <stdio.h>
#include <stdlib.h>

int main(){
    long val=0x41414141;
    char buf[20];

    printf("Correct val's value from 0x41414141 -> 0xdeadbeef!\n");
    printf("Here is your chance: ");
    scanf("%24s",&buf);

    printf("buf: %s\n",buf);
    printf("val: 0x%08x\n",val);

    if(val==0xdeadbeef){
        setreuid(geteuid(),geteuid());
        system("/bin/sh");
    }
    else {
        printf("WAY OFF!!!!\n");
        exit(1);
    }

    return 0;
}
```

`Scanf` is not bounds checked, the two buffers `val` and `buf` are right next to each other. By crafting a string that overflows the bounds of `buf`, we can overwrite `val`. The desired string, `deadbeef`, should be read backwards and divided into the hex characters `FE`, `EB`, `DA` and `ED`, which translates to extended ascii numbers and the characters `▐¡╛∩`. These need to be specified in reverse, so a sample solution string is `01234567890123456789φ┌δ■`