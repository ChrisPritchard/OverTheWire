
.globl _start

_start:
    xor %eax, %eax
    movb $1, %al
    xor %ebx, %ebx
    int $0x80