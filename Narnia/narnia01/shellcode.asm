
.globl _start

_start:
    mov $2, %edi
    mov $60, %eax
    syscall