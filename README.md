# GodeTech.Microservices.SharedServices

`GodeTech.Microservices.SharedServices` is a collection of services which are used in particularly every project and typically copy\pasted from project to project.

## Quick Start

In order to use microservice few simple steps are required:
1. Create ASP.NET Website application using **Visual Studio** or **dotnet cli**.
2. Reference latest version of `Godel.Microservice.Core` and ``Godel.Microservice.SharedServices` nuget packages.
3. Add `Godel.Microservice.SharedServices` initializer to your `Startup.cs` file to create initializers used to configure pipeline:
```c#
yield return new SharedServicesInitializer(Configuration);
```

### REST API configuration
Please use the following snippet to configure service which uses REST API only:

```c#
    public class Startup : MicroserviceStartup
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override IEnumerable<IMicroserviceInitializer> CreateInitializers()
        {
            yield return new DeveloperExceptionPageInitializer(Configuration);
            yield return new HttpsInitializer(Configuration);

            yield return new GenericInitializer((app, env) => app.UseRouting());

            yield return new ApiInitializer(Configuration);

            yield return new SharedServicesInitializer(Configuration);
        }
    }
```

# Resolvers

## ContentType Resolver
`IContentTypeResolver` method `GetByFilePath(string filePath)` defines a mime type from extension of passing file path.

### Advanced usage
```c#
    public class ValuesController : ControllerBase
    {
        private readonly IContentTypeResolver _contentTypeResolver;

        public ValuesController(IContentTypeResolver contentTypeResolver)
        {
            _contentTypeResolver = contentTypeResolver;
        }

        [HttpGet]
        public IActionResult GetContentType(string filePath)
        {
            string contentType = _contentTypeResolver.GetByFilePath(filePath);

            return Ok(contentType);
        }
    }
```

```
TEST VALUE: filePath = "test.json"
RESULT VALUE: application/json
```
# Providers

## DateTime Provider
`IDateTimeProvider` method `GetUtcNow()` returns current UTC date and time.

### Advanced usage
```c#
    public class ValuesController : ControllerBase
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ValuesController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        [HttpGet]
        public IActionResult GetUTCDateTimeNow()
        {
            DateTime dateTimeNow = _dateTimeProvider.GetUtcNow();

            return Ok(dateTimeNow);
        }
    }
```

```
RESULT VALUE: "2020-10-18T20:34:10.7520426Z"
```

# Services

## Directory Service
`IDirectoryService` methods work with directories on disk.


### Advanced usage
```c#
    public class ValuesController : ControllerBase
    {
        private readonly IDirectoryService _directoryService;

        public ValuesController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        [HttpGet]
        public IActionResult DirectoryExists(string path)
        {
            bool directoryExists = _directoryService.Exists(path);

            return Ok(directoryExists);
        }
    }
```

```
TEST VALUE: path = "C:\Windows"
RESULT VALUE: true
```

## File Service
`IFileService` methods work with files on disk.

### Advanced usage
```c#
    public class ValuesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public ValuesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult FindAll(string path, string mask)
        {
            IEnumerable<string> files = _fileService.FindAll(path, mask);

            return Ok(files);
        }
    }
```
```
TEST VALUE: path = "d:\test\", mask = "*.exe"
RESULT VALUE: ["d:\\Test\\test1.exe", "d:\\Test\\test2.exe"]
```


## Path Service
`IPathService` methods work with path on disk.

# Factories

## Guid Factory
`IGuidFactory` methods create Guid type objects.

### Advanced usage
```c#
    public class ValuesController : ControllerBase
    {
        private readonly IGuidFactory _guidFactory;

        public ValuesController(IGuidFactory guidFactory)
        {
            _guidFactory = guidFactory;
        }

        [HttpGet]
        public IActionResult NewGuid()
        {
            string id = _guidFactory.NewAsString();

            return Ok(id);
        }
    }
```

```
RESULT VALUE: 258920d2-eb02-4c77-b636-d63c43b07390
```

## TempFile Factory
`ITempFileFactory` with method `Create(string tempFolder)` creates an `ITempFile` type object for working with temporary files. `ITempFile` is a disposable and can be removed after using. `ITempFile` works with files.



### Advanced usage
```c#
    public class ValuesController : ControllerBase
    {
        private readonly ITempFileFactory _tempFileFactory;

        public ValuesController(ITempFileFactory tempFileFactory)
        {
            _tempFileFactory = tempFileFactory;
        }

        [HttpGet]
        public IActionResult TempFile(string tempFolder)
        {
            ITempFile tempFile = _tempFileFactory.Create(tempFolder);

            string path = tempFile.Path;

            string test = "Testing 1-2-3";

            byte[] byteArray = Encoding.ASCII.GetBytes(test);

            MemoryStream stream = new MemoryStream(byteArray);

            tempFile.WriteAsync(stream);

            return Ok(path);
        }
    }
```

```
RESULT: A file with name "201e3212-f244-4f29-abd7-e1a799b6d855" was created in the "C:\Downloads" folder. The file contains a "Testing 1-2-3" row.
```

# Serializers

## Json Serializer
`IJsonSerializer` contains methods for Serialize and Deserialize object to json.

```c#
    public class ValuesController : ControllerBase
    {

        private readonly IJsonSerializer _jsonSerializer;

        public ValuesController(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        [HttpGet("json-deserialize")]
        public IActionResult JsonDeserialize(string objectInJsonFormat)
        {
            WeatherForecast model = _jsonSerializer.Deserialize<WeatherForecast>(objectInJsonFormat);

            return Ok();
        }

        [HttpGet("json-serialize")]
        public IActionResult JsonSerialize(WeatherForecast model)
        {
            string json = _jsonSerializer.Serialize(model);

            return Ok(json);
        }
    }
```