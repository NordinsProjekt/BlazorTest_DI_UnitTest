namespace UnitTest.Interface
{
    public interface IPersonTest_DS
    {
        void ConfirmThatPersonDidntChanged();
        void ConfirmThatPersonGotChanged();
        void CreateANewPerson_ReturnSuccess();
        void DeletePerson_ReturnFailBelowIndex();
        void DeletePerson_ReturnFailOverIndex();
        void DeletePerson_ReturnSuccess();
        void EditPersonIDOverIndex_ReturnFail();
        void EditPersonPersonEmptyString_ReturnFail();
        void EditPersonPersonNullValue_ReturnFail();
        void EditPerson_ReturnSuccess();
        void GetAllPersonsNotNull();
        void GetAllPerson_GetListObjectBack();
        void GetPersonWithID_NotNull();
    }
}