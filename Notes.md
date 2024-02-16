# 빌드 오류 해결 방법

.NET SDK는 MacOS SDK 관련 코드를 찾을 때, `xcode-select --print-path` 명령어를 사용하여 나타나는 것과 같은 경로를 찾는다. 그런데 설정된 경로가 요즈음 Xcode가 배포되는 방식과 일치하지 않아 빌드 오류가 발생할 수 있다.

1. 일단 App Store에서 최신 버전의 Xcode 앱을 다운로드 받는다. Xcode는 IDE 말고도 앱 패키지 안에 애플 제품의 컴파일러, 라이브러리들이 보통 한데 묶여서 배포되곤 한다.
1. 설치가 오래 걸릴 수 있다. 앱 스토어 상에서 설치가 끝난 것으로 나오면, `/Applications/Xcode.app` 디렉터리가 잘 생성되었는지 확인한다.
1. `xcode-select --install` 명령어를 실행하여 Xcode 명령줄 도구들을 설치한다.
1. `xcode-select --print-path` 명령어를 터미널에서 실행해봤을 때, `/Application/Xcode.app`이 아니면 변경이 필요한 상황이다.
1. `sudo xcode-select --switch /Applications/Xcode.app` 명령을 실행하여 경로를 변경한다.

# ApiDefinition.cs에 들어있던 도움말 사본

The first step to creating a binding is to add your native framework ("MyLibrary.xcframework") to the project.

Open your binding csproj and add a section like this:

```xml
<ItemGroup>
    <NativeReference Include="MyLibrary.xcframework">
    <Kind>Framework</Kind>
    <Frameworks></Frameworks>
    </NativeReference>
</ItemGroup>
```

Once you've added it, you will need to customize it for your specific library:

- Change the Include to the correct path/name of your library
- Change Kind to Static (.a) or Framework (.framework/.xcframework) based upon the library kind and extension.
- Dynamic (.dylib) is a third option but rarely if ever valid, and only on macOS and Mac Catalyst
- If your library depends on other frameworks, add them inside `<Frameworks>...</Frameworks>`

Example:

```xml
<NativeReference Include="libs\MyTestFramework.xcframework">
    <Kind>Framework</Kind>
    <Frameworks>CoreLocation ModelIO</Frameworks>
</NativeReference>
```

Once you've done that, you're ready to move on to binding the API...

Here is where you'd define your API definition for the native Objective-C library.

For example, to bind the following Objective-C class:

```objectivec
@interface Widget : NSObject {
}
```

The C# binding would look like this:

```csharp
[BaseType (typeof (NSObject))]
interface Widget {
}
```

To bind Objective-C properties, such as:

```objectivec
@property (nonatomic, readwrite, assign) CGPoint center;
```

You would add a property definition in the C# interface like so:

```csharp
[Export ("center")]
CGPoint Center { get; set; }
```

To bind an Objective-C method, such as:

```objectivec
-(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
```

You would add a method definition to the C# interface like so:

```csharp
[Export ("doSomething:atIndex:")]
void DoSomething (NSObject object, nint index);
```

Objective-C "constructors" such as:

```objectivec
-(id)initWithElmo:(ElmoMuppet *)elmo;
```

Can be bound as:

```csharp
[Export ("initWithElmo:")]
NativeHandle Constructor (ElmoMuppet elmo);
```

For more information, see [https://aka.ms/ios-binding](https://aka.ms/ios-binding).

# Objective Sharpie 사용법 가이드

- [https://learn.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-c-libraries?tabs=macos](https://learn.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-c-libraries?tabs=macos)
- [https://aka.ms/ios-binding](https://aka.ms/ios-binding)
