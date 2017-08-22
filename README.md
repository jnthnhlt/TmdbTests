# TmdbTests

To run tests, please use the following steps:

1. Edit the test.runsettings file in the TmdbTests project, or create a new one.

   ```<?xml version="1.0" encoding="utf-8"?>
    <RunSettings>
      <!-- Parameters used by tests at runtime -->
      <TestRunParameters>
        <Parameter name="baseUrl" value="" />
        <Parameter name="apiKey" value="" />
      </TestRunParameters>
    </RunSettings>```

This will allow you to change the baseUrl and apiKey values.
The URL used for initial testing is: https://api.themoviedb.org/3/

2. Use the default test data, or add some of your own to validate.  To do this, add your expected movie data to the TmdbTests/ExternalData directory. Use an existing culture code directory, or create the appropriate one that you need.  The format should be language-region, in the form of xx-XX.  The data should follow the schema provided by tmdb.  An example is provided below.

```{
  "adult": false,
  "backdrop_path": "/fCayJrkfRaCRCTh8GqN30f8oyQF.jpg",
  "belongs_to_collection": null,
  "budget": 63000000,
  "genres": [
    {
      "id": 18,
      "name": "Drama"
    }
  ],
  "homepage": "",
  "id": 550,
  "imdb_id": "tt0137523",
  "original_language": "en",
  "original_title": "Fight Club",
  "overview": "A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground \"fight clubs\" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.",
  "popularity": 0.5,
  "poster_path": null,
  "production_companies": [
    {
      "name": "20th Century Fox",
      "id": 25
    }
  ],
  "production_countries": [
    {
      "iso_3166_1": "US",
      "name": "United States of America"
    }
  ],
  "release_date": "1999-10-12",
  "revenue": 100853753,
  "runtime": 139,
  "spoken_languages": [
    {
      "iso_639_1": "en",
      "name": "English"
    }
  ],
  "status": "Released",
  "tagline": "How much can you know about yourself if you've never been in a fight?",
  "title": "Fight Club",
  "video": false,
  "vote_average": 7.8,
  "vote_count": 3439
}```

3. Use dotnet test to perform a test run.  Navigate to the test project directory and use the following command from the windows command line:

dotnet test -s test.runsettings  > output.txt

4. Open the output to view results.  More documentation can be found here: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test?tabs=netcore1x




