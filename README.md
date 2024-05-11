# SCPSL.AssemblyPublicizer

Publicizes SCPSL assemblies into SCPSL_Data/Managed

# Example action

Publicize one assembly.
```yaml
    - name: Publicize Assemblies
      uses: killers0992/scpsl.assemblypublicizer@master
      with:
        assemblies: 'Assembly-CSharp.dll'
```

Publicize multiple assemblies.
```yaml
    - name: Publicize Assemblies
      uses: killers0992/scpsl.assemblypublicizer@master
      with:
        assemblies: 'Assembly-CSharp.dll,Mirorr.dll'
```
