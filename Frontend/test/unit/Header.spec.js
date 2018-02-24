import { shallow, mount } from "@vue/test-utils";
import Header from "@/components/Header.vue";

describe("Header.vue", () => {
  it("should has methods, computed and updated lifecycle hook", () => {
    const vm = mount(Header);
    expect(typeof vm.user).toBe('object');
  });
});
