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

The buffer is 128 chars, so after 128 we have overloaded the buffer and start overwriting the main code. The strcpy command is around 56 32bit words down, so we need to overwrite by a further 1152 bytes...I think. I gave this a go, but it wasn't successful. 

However I did discover that if I overflowed the buffer by 136 characters, the final four characters overwrote the return address from the main function. From this, after a bit of further research, I worked out that the approach might be to include the shell code in the buffer, then jump to it by overflowing the return address. Hmm.

At this point I spent some time doing some learning. The following three videos from LiveOverflow were very helpful (they're in a row as part of the Binary Hacking playlist):

- [First Stack Buffer Overflow to modify Variable - bin 0x0C](https://www.youtube.com/watch?v=T03idxny9jE&list=PLhixgUqwRTjxglIswKp9mpkfPNfHkzyeN&index=13)
- [Buffer Overflows can Redirect Program Execution - bin 0x0D](https://www.youtube.com/watch?v=8QzOC8HfOqU&list=PLhixgUqwRTjxglIswKp9mpkfPNfHkzyeN&index=14)
- [First Exploit! Buffer Overflow with Shellcode - bin 0x0E](https://www.youtube.com/watch?v=HSlhY4Uy8SA&list=PLhixgUqwRTjxglIswKp9mpkfPNfHkzyeN&index=15)

On top of that, the original article by AlephOne on stack overflows fills in the missing pieces, and is excellent:

[Smashing The Stack For Fun And Profit](http://phrack.org/issues/49/14.html#article)

