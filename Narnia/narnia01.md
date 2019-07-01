# Narnia 1

Password: `efeidiedae`

Running /narnia/narnia1 gives the message `Give me something to execute at the env-variable EGG`

The source code for the problem is (no license, again):

```C
#include <stdio.h>

int main(){
    int (*ret)();

    if(getenv("EGG")==NULL){
        printf("Give me something to execute at the env-variable EGG\n");
        exit(1);
    }

    printf("Trying to execute EGG!\n");
    ret = getenv("EGG");
    ret();

    return 0;
}
```

I attempted to build something sneaky [like this](./narnia01/failed-1.c) (compiled with gcc) but it didnt work. Ultimately a bit of research revealed that this is a shellcode problem: the goal is to place into the environment variable some text that is the hex encoding of legitimate machine code, so when the program casts it to a function, the function is valid.

Shellcode is the nickname for position-independent code, machine code that can be placed anywhere in memory and still function as intended. It needs to not depend on any stack variables, and to contain no null values (that is, to not contain the text `\x00`) so that it can function both as a full string and as machine code (the null value would prematurely terminate the string, ruining the shellcode).

While its entirely possible to grab some shellcode online (e.g. from the [shellcode database](http://shell-storm.org/shellcode/)), I took this as a learning challenge and decided to write my own.

First I tried doing so solely through C, [like this](./narnia01/failed-2.c), but couldn't get the output right. I was compiling using the command `gcc narnia01-shellcode.c -O0 -o shellcode` and dumping the assembly with `objdump -d shellcode`, but couldn't get rid of the null bytes - seemed to be some sort of optimisation I couldn't get rid of.

Next I tried with Assembly, but ran into a problem: none of the assembly I would write would work. It would always result in a seq fault. I thought it might be processor architecture, but when I tried to assemble on the narnia remote machine it would work and both the remote machine and my dev machines had the same x86-x64 architecture. Ultimately this turned out to be a quirk of WSL: the windows subsystem is 64 bit only - no 32 bit assembly at all. Linux 64 bit machines still allow 32 bit via compatibility. If I wrote valid 64 bit assembly it would work. However, most shell code tutorials assume 32 bit so I wanted to work with that. Remote assembling only, it would seem.
